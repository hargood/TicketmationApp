/**
 * @version 1.1;
 * @overview pEngine.proxy
 *
 * Javascript promise based framework
 * That enables the ability to communicate
 * with EMV devices
 *
 */
var pEngine = {
       APPROVED                                : 'APPROVED',
       AUTH                                    : 'auth',
	   BASE_URL                                : 'https://localhost:60353/api/',
       CALLBACK_ERROR                          : 'Invalid Callback Specified',
       CAPTURE_RECEIPT                         : 'CaptureReceipt',
       CARD_NOTIFICATION                       : 'CardNotification',
       CARD_DETAILS                            : 'CardDetails',
       CHIP_DNA_ERROR                          : 'ChipDnaError',
       CHANGE_PASSWORD                         : 'ChangePassword',
       COMM_ERROR                              : 'Your connection to pEngine.proxy is down or is not running. Please make sure the program is visible in the bottom right sys tray of the computer. You will see a small credit card icon on the bottom. Please hit dismiss, correct and try again. ',
       CREDENTIALS_FAIL                        : 'CredentialsFail',
       DECLINED                                : 'DECLINED',
       ENABLE_TIP                              : 'EnableTip',
       EMPTY_PARAM                             : {},
       EMPTY_STRING                            : '',
       ERROR                                   : 'Error',
       ERROR_VALIDATION_CURRENCY               : 'Decimal places are not allowed in the Amount. Please specify currency as such (100 = 1.00), please correct and try again',
       EVENT_MAX_LIMIT                         : 100,
       GETSTATUS                               : 'GetStatus',
	   NULL                                    : '',
       INFO_LOG                                : 'INFO',
       INTERVAL                                : 5000,
       NO_MSG                                  : '',
       PAYMENT_DEVICE_AVAILABILITY_CHANGE      : 'PaymentDeviceAvailabilityChange',
       POLL_HANDLE                             : {},
       PRINT_AFTER_SALE                        : 1,
       RESPONSE                                : {},
       RESPONSE_LOG                            : 'RESPONSE',
       SALE                                    : 'sale',
       SALE_STARTED                            : 'SaleStarted',
       SALE_INITIATED                          : 'SaleInitiated',
       SALE_CONFIRMED                          : 'SaleConfirmed',
       SALE_REFUNDED                           : 'SaleRefunded',
       SET_IDLE_MESSAGE                        : 'SetIdleMessage',
       SALE_VOIDED                             : 'SaleVoided',
       TRANSACTION                             : {},
       TRANSACTION_FINISHED                    : 'TransactionFinished',
       TRANSACTION_UPDATE                      : 'TransactionUpdate',
       TRANSACTION_PAUSED   				   : 'TransactionPaused',
       TMS_UPDATE                              : 'TmsUpdate',
       TIP_ADJUST                              : 'TipAdjust',
       UPDATE_TRANSACTION_PARAMETERS_FINISHED  : 'UpdateTransactionParametersFinished',

       /* @ HELPER METHODS */
       /* @ Used in conjunction with libraries */
       _hasKeyValue : function(key, value, eventArgs) {
            for (i = 0; i < eventArgs.length; i++) {
                var param = eventArgs[i];
                if (param.Key == key && param.Value == value)
                    return true;
            }
            return false;
        },

	   /**
		 * Clears Client Based Polling
		 *
		 * @param {na}
		 * @return {void}
		 */
       _killPolling : function() {
             setTimeout(function(){ clearInterval(pEngine.POLL_HANDLE); }, 5000);
       },

	   /**
		 * Logs data to console.log and to a div that is provided
		 *
		 * @param {String} Log_type
		 * @param {Array} Data
		 * @param {Sender} Event Name
		 * @param {Array} Event Arguments
		 * @return {void}
		 */
       _log : function(log_type, data, sender, eventArgs) {
            if (log_type == pEngine.INFO_LOG) {
				console.error(Date());
				$.each(data, function(Key, Value) {
					console.log(Key + ' = ' + Value);
				});
			} else if (log_type == pEngine.RESPONSE_LOG) {
				console.error(Date() + 'Event Name:' + sender);
				for (i = 0; i < eventArgs.length; i++) {
					var param = eventArgs[i];

                    switch(param.Key) {
                    	case 'SaleError': $('#displayLog').html('<b>' + param.Key + ':' + param.Value + '</b>');break;
                    	default : console.log(param.Key + ' = ' + param.Value); break;
                    }
				}
			}
       },

	   /**
		 * Issues an AJAX post to one of the internal endpoints and passes response to a call back method
		 *
		 * @param {String} URI of end point
		 * @param {Array} Misc Paramaters being passed to end point
		 * @param {string} Callback function to execute
		 * @return {void}
		 */
 	   _post : function(url, params, callback) {
			try {
              $.post( url, $.param(params, true), function( json ) {
					  if (typeof(json) === "object" && callback && typeof(callback) === "function") {
						callback(json);
					  } else if (typeof(json) === "string" && callback && typeof(callback) === "function") {
						callback(JSON.parse(json));
					  } else {
						alert(pEngine.CALLBACK_ERROR);
					  }
                }).fail(function (jqXHR, textStatus, errorThrown) {

                    /* Kill polling */
                    pEngine._killPolling();

                    /* Advise of error */
                    pEngine._write(pEngine.COMM_ERROR, 3);
			  });
			} catch (e) {
			  alert(e.message);
			}
	   },

	   /**
		 * Removes decimal points (Note: Credit Call does not allow decimals)
		 *
		 * @param {String} Number passed as a string
		 * @return {String} Number with decimals removed. 5.00 would be returned as 500
		 */
       _removeDecimal : function(number) {
            var amount = String(number);
            return amount.replace(".","");
       },

	   /**
		 * Removes ** in PAN
		 *
		 * @param {String} PAN returned from Credit call
		 * @return {String} PAN with all * removed
		 */
       _removePan : function(str) {
            var str = String(str);
            return str.replace(/\*/g, "");
       },

	   /**
		 * Returns Credit call amount and returns back into decimal format
		 *
		 * @param {String} Number as string
		 * @return {String} 500 is returned back as 5.00
		 */
	   _returnCurrency : function(number) {
             var num = String(number);
             var last2 = num.slice(-2);
             var first = num.slice(0,(num.length - 2) );
             return first + '.' + last2;
	   },

	   /**
		 * Converts multiple data responses into a single response object that can be referenced.
		 * All response data is returned as pEngine.RESPONSE, you can access a node like
		 * pEngine.RESPONSE.amount would give you the amount of the transaction returned
		 *
		 * @param {Array} Raw data returned from Credit Call
		 * @return {Void}
		 */
       _setResponse : function(eventArgs) {
            for (i = 0; i < eventArgs.length; i++) {
                var param = eventArgs[i];
                switch(param.Key) {
					case 'TOTAL_AMOUNT':
					     pEngine.RESPONSE.amount = param.Value;
					     break;

					case 'TRANSACTION_RESULT':
					     pEngine.RESPONSE.result = param.Value;
					     break;

					case 'SIGNATURE_VERIFICATION_REQUIRED':
					     pEngine.RESPONSE.signatureRequired = param.Value;
					     break;

					case 'SIGNATURE_CAPTURED':
					     pEngine.RESPONSE.signatureCaptured = param.Value;
					     break;

					case 'RECEIPT_DATA':
					     pEngine.RESPONSE.receipt = param.Value;
					     break;

					case 'CARD_REFERENCE':
					     pEngine.RESPONSE.cardReference = param.Value;
					     break;

					case 'CARDEASE_REFERENCE':
					     pEngine.RESPONSE.cardEaseReference = param.Value;
					     break;

					case 'AUTH_DATE_TIME':
					     pEngine.RESPONSE.authTime = param.Value;
					     break;

					case 'PAN_MASKED':
					     pEngine.RESPONSE.panMasked = param.Value;
					     break;

					case 'EXPIRY_DATE':
					     pEngine.RESPONSE.expireDate = param.Value;
					     break;

					case 'MERCHANT_NAME':
					     pEngine.RESPONSE.merchantName = param.Value;
					     break;

					case 'REFERENCE':
					     pEngine.RESPONSE.reference = param.Value;
					     break;

					case 'CARD_SCHEME':
					     pEngine.RESPONSE.cardType = param.Value;
					     break;

					case 'CARD_HASH':
					     pEngine.RESPONSE.cardHash = param.Value;
					     break;

					case 'PAN_SEQUENCE':
					     pEngine.RESPONSE.panSequence = param.Value;
					     break;

					case 'TRANSACTION_SOURCE':
					     pEngine.RESPONSE.transSource = param.Value;
					     break;

					case 'TRANSACTION_TYPE':
					     pEngine.RESPONSE.transType = param.Value;
					     break;

					case 'CARDHOLDER_VERIFICATION':
					     pEngine.RESPONSE.transVerification = param.Value;
					     break;

					case 'AUTH_CODE':
					     pEngine.RESPONSE.authCode = param.Value;
					     break;
			    }
            }
            return false;
        },

	   /**
		 * Displays the current state/event data returned from Credit Call
		 *
		 * @param {String} Base message provided
		 * @param {Array} Raw data returned from Credit Call
		 * @return {Void}
		 */
        _state : function(msg, eventArgs) {
			for (i = 0; i < eventArgs.length; i++) {
				var param = eventArgs[i];
                msg = msg.replace(param.Key, param.Value);
			}
            $('#displayLog').html(msg);
        },

	   /**
		 * Custom function, can be used to display different icons depending
		 * on where the current transaction status is
		 *
		 * @param {String} Base message provided
		 * @param {Array} Raw data returned from Credit Call
		 * @return {Void}
		 */
       _write : function(msg, icon) {
            switch(icon) {
            	case 1: var img = '<img src="/images/creditcard.gif">' ; break;
            	case 2: var img = '<img src="/images/loading.gif">' ; break;
            	case 3: var img = '<img src="/images/remove.gif">' ; break;
            	case 4: var img = '<img src="/images/success.gif">' ; break;
            }

            /* Only update UI if message */
            if (msg.length > 0) {
              $('#displayLog').html(msg);
            }

            /* Update image */
            $('#emv-status').html(img);
       },

	   /**
		 * Determines if the amount provided is free of any decimals
		 * on where the current transaction status is

		 * @param {String} Amount of the transaction
		 * @return {Void}
		 */
       _validateAmount : function(Amount) {
			var amt = Amount.toString();
			if (amt.indexOf(".") > -1) {
			   return alert(pEngine.ERROR_VALIDATION_CURRENCY);
			} else {
				return true;
		    }
       },

       /* LIBRARY METHODS */
       /* Used to directly access the proxy and chipDNA */

	   /**
		 * Confirms a prior authorized sale
		 *
		 * @param {string} Reference number of transaction
		 * @param {int} Amount no decimals
		 * @return {void} callback function
		 */
       confirm : function(Refnum, Amount) {
			try {
			    return new Promise(function(resolve, reject) {
						pEngine._post(pEngine.BASE_URL + 'confirm', { Amount : Amount, Refnum : Refnum }, function(json) {
	                           if (((json.Error == false) ? true : false)) {
                                 resolve(json.Reference);
                               } else {
                                 reject('Error: ' + json.Message);
                               }
						 } );
			    });
	        }
			catch(err) {
			    alert('Unregistered exception just occured in confirm method ' + err.message);
			}
       },

	   /**
		 * Connects to pEngine.proxy and returns all queued up events
		 *
		 * @param {none}
		 * @return {void} callback function
		 */
       events : function() {
			try {
			    return new Promise(function(resolve, reject) {
						pEngine._post(pEngine.BASE_URL + 'getevents', {  }, function(json) {
	                           if (((json.Error == false) ? true : false)) {
                                 pEngine.eventsHandler(json);
                                 resolve(json.Error);
                               } else {
                                 reject('Error: ' + json.Message);
                               }
						 } );
			    });
	        }
			catch(err) {
			    alert('Unregistered exception just occured in events method ' + err.message);
			}
       },

	   /**
		 * Handler to process the various queued events returned by pEngine.proxy
		 *
		 * @param {object} Contains all event data in a structure
		 * @return {void} callback function
		 */
       eventsHandler : function(chipEvents) {
			try {
				if (chipEvents !== undefined && chipEvents !== null) {
					for (y = 0; y < chipEvents.Events.length; y++) {

						var sender = chipEvents.Events[y].TypeName;
						var eventArgs = chipEvents.Events[y].EventParameters;

						console.error(sender);

						switch(sender) {
							case pEngine.TRANSACTION_FINISHED:
								pEngine.onTransactionFinished(sender, eventArgs);
								break;

							case pEngine.TRANSACTION_UPDATE:
								pEngine.onTransactionUpdate(sender, eventArgs);
								break;

							case pEngine.TRANSACTION_PAUSED:
								pEngine.onTransactionPaused(sender, eventArgs);
								break;

							case pEngine.UPDATE_TRANSACTION_PARAMETERS_FINISHED:
								pEngine.onUpdateTransactionParametersFinished(sender, eventArgs);
								break;

							case pEngine.CAPTURE_RECEIPT:
								pEngine.onCaptureReceipt(sender, eventArgs);
								break;

							case pEngine.CARD_NOTIFICATION:
								pEngine.onCardNotification(sender, eventArgs);
								break;

							case pEngine.CARD_DETAILS:
								pEngine.onCardDetails(sender, eventArgs);
								break;

							case pEngine.CREDENTIALS_FAIL:
								pEngine.onCredentialsFail(sender, eventArgs);
								break;

							case pEngine.PAYMENT_DEVICE_AVAILABILITY_CHANGE:
								pEngine.onPaymentDeviceAvailabilityChange(sender, eventArgs);
								break;

							case pEngine.TMS_UPDATE:
								pEngine.onTmsUpdate(sender, eventArgs);
								break;

							case pEngine.ERROR:
								pEngine.onError(sender, eventArgs);
								break;

							case pEngine.CHIP_DNA_ERROR:
								pEngine.onChipDnaError(sender, eventArgs);
								break;

							case pEngine.SET_IDLE_MESSAGE:
								pEngine.onSetIdleMessage(sender, eventArgs);
								break;

							case pEngine.SALE_STARTED:
								pEngine.onSaleStarted(sender, eventArgs);
								break;

							case pEngine.SALE_INITIATED:
								pEngine.onSaleInitiated(sender, eventArgs);
								break;

							case pEngine.SALE_CONFIRMED:
								pEngine.onSaleConfirmed(sender, eventArgs);
								break;

							case pEngine.SALE_REFUNDED:
								pEngine.onSaleRefunded(sender, eventArgs);
								break;

							case pEngine.SALE_VOIDED:
								pEngine.onSaleVoided(sender, eventArgs);
								break;

							case pEngine.ENABLE_TIP:
								pEngine.onEnableTip(sender, eventArgs);
								break;

							case pEngine.TIP_ADJUST:
								pEngine.onTipAdjust(sender, eventArgs);
								break;

							case pEngine.CHANGE_PASSWORD:
								pEngine.onChangePassword(sender, eventArgs);
								break;

							default:
								pEngine.onUnrecognizedSender(sender, eventArgs);
								break;
						}
					}
				}
	        }
			catch(err) {
				alert('Unregistered exception just occured in events handler ' + err.message);
			}
       },

	   /**
		 * Returns the current queued events returned by pEngine.proxy
		 *
		 * @param {none}
		 * @return {void} callback function
		 */
       getEvents : function() {
			try {
                pEngine.events().then(function(error) { } ).catch(function(errmsg) { pEngine._write(errmsg, 3); });
			}
			catch(err) {
			    alert('Unregistered exception just occured in idle message method ' + err.message);
			}
       },

	   /**
		 * Sets the default "idle" message on a device. Normally defaults to "This lane Closed"
		 *
		 * @param {string} Message that should appear on device
		 * @return {void} callback function
		 */
       idleMessage : function(message) {
			try {
			     pEngine._post(pEngine.BASE_URL + 'setidlemessage', { Message : message }, function(json) {console.log(json) });
			}
			catch(err) {
			    alert('Unregistered exception just occured in idle message method ' + err.message);
			}
       },


	   /**
		 * Processes a sale or auth (An AUTH is a non confirmed sale)
		 *
		 * @param {string} Reference number of transaction
		 * @param {int} Amount no decimals
		 * @param {string} Type of transaction
		 * @param {string} Determine how to handle tips
		 * @return {void} callback function
		 */
       sale : function(Refnum, Amount, Type, TipType) {
			try {

				/* Verify device is ready prior
				 * to running commands against it
				 *********************************/
				pEngine.status().then(function(json) {
	                if (((json.Error == false) ? true : false)) {
                        pEngine.reset();
                        pEngine.transact(Refnum, Amount, Type, TipType).then(function(reference) { pEngine._write('Sale Initiated on device [' + reference + '}', 2) } ).catch(function(errmsg) { pEngine._write(errmsg, 3); });
	                } else {
	                    pEngine._write('Device is not available for transactions, response is ' + json.PaymentDeviceStatus, 3);
	                }
				}).catch(function(errmsg){
				    pEngine._write('Error reading the device:' + errmsg, 3);
				});
	        }
			catch(err) {
			    alert('Unregistered exception just occured in sale method' + err.message);
			}
       },

	   /**
		 * Returns device availibility information
		 *
		 * @param {none}
		 * @return {void} callback function
		 */
       status : function() {
			try {
			    return new Promise(function(resolve, reject) {
			              $.post( pEngine.BASE_URL + 'status', $.param({}, true), function( json ) {
								  if (typeof(json) === "object") {
									resolve(json);
								  } else if (typeof(json) === "string") {
									resolve(JSON.parse(json));
								  } else {
						  		    reject(pEngine.CALLBACK_ERROR);
								  }
			                }).fail(function (jqXHR, textStatus, errorThrown) {
						  		    reject(errorThrown);
						    });
			    })
	        }
			catch(err) {
			    alert('Unregistered exception just occured in send method ' + err.message);
			}
      },


	   /**
		 * Refunds a previously settled sale
		 *
		 * @param {string} Reference number of transaction
		 * @param {int} Amount no decimals
		 * @return {void} callback function
		 */
       refund : function(Refnum, Amount) {
			try {
			     pEngine._post(pEngine.BASE_URL + 'refund', { Amount : Amount, SaleReference : Refnum }, pEngine.nullCallback);
	        }
			catch(err) {
			    alert('Unregistered exception just occured in refund method ' + err.message);
			}
       },

	   /**
		 * Resets the global transaction variables
		 *
		 * @param {none}
		 * @return {none}
		 */
       reset : function() {
				pEngine.TRANSACTION = {
					amount: 0,
					inProcess: false,
					reference: pEngine.EMPTY_STRING,
					transType: pEngine.EMPTY_STRING
				};
       },

   /**
	 * Processes a sale or auth (An AUTH is a non confirmed sale)
	 *
	 * @param {string} Reference number of transaction
	 * @param {int} Amount no decimals
	 * @param {string} Type of transaction
	 * @param {string} Determine how to handle tips
	 * @return {void} callback function
	 */
      transact : function(Refnum, Amount, Type, TipType) {
			try {
				    return new Promise(function(resolve, reject) {
		                if (pEngine._validateAmount(Amount)) {
							pEngine._post(pEngine.BASE_URL + Type, { Amount : Amount, Refnum : Refnum, TipType : TipType }, function(json) {
		                           if (((json.Error == false) ? true : false)) {
									 pEngine.POLL_HANDLE = setInterval("pEngine.getEvents()", pEngine.INTERVAL);
									 pEngine.TRANSACTION = { transType : Type, amount : json.Amount, inProcess : true, reference : json.Reference };
                                     resolve(json.Reference);
                                   } else {
                                     reject('Error: ' + json.Message);
                                   }

							 } );
					    } else {
                            reject('Error: The amount must be without decimals, 2.00 should be 200');
					    }
				    });
	        }
			catch(err) {
			    alert('Unregistered exception just occured in transact method ' + err.message);
			}
       },

	   /**
		 * Voids an unsettled sale/auth
		 *
		 * @param {string} Reference number of transaction
		 */
       void : function(refnum) {
			try {
			     pEngine._post(pEngine.BASE_URL + 'void', { SaleReference : refnum }, pEngine.nullCallback);
			}
			catch(err) {
			    alert('Unregistered exception just occured' + err.message);
			}
       },

        /* CALLBACK METHODS */
       /* Process returned data from the Proxy/ChipDNA */
       nullCallback : function() {
			try {
                /* Void Passive */
	        }
			catch(err) {
			    alert('Unregistered exception just occured in null callback ' + err.message);
			}
	   },

       onTransactionFinished : function(sender, eventArgs) {
			try {
				pEngine._log(pEngine.RESPONSE_LOG, pEngine.EMPTY_PARAM, "onTransactionFinished", eventArgs);

				/* If the pin pad was cancelled
				 * Skip this routine
				 **********************************/
				if (pEngine._hasKeyValue("ERRORS", "PinPadTransactionTerminated", eventArgs)) {
                   pEngine._write('Pin Pad has been terminated by the user', 3);
                   pEngine._killPolling();
				} else if (pEngine._hasKeyValue("ERRORS", "ChipCardRemoved", eventArgs)) {
                   pEngine._write('The Chip card was removed from the device', 3);
                   pEngine._killPolling();
				} else if (pEngine._hasKeyValue("ERRORS", "PinPadUserCancelled", eventArgs)) {
                   pEngine._write('The transaction was cancelled by the user', 3);
                   pEngine._killPolling();
				} else {

					/* Set response into a single
					 * response object
					 *****************************/
					pEngine._setResponse(eventArgs);

                    if (pEngine.RESPONSE.result == pEngine.DECLINED) {
	                   pEngine._write('The transaction was declined {' + pEngine.RESPONSE.cardType + ' - ' + pEngine.RESPONSE.result + '}', 3);
	                   return pEngine._killPolling();
                    }  else if (pEngine.RESPONSE.result == pEngine.APPROVED) {
	                    pEngine._write('The transaction was approved, confirming the Sale', 4);

					    /* If the transaction is a Sale,
					     * proceed to confirm
					     ******************************/
					    if (pEngine.TRANSACTION.inProcess && pEngine.TRANSACTION.transType == 'sale') {
	                      pEngine.TRANSACTION.inProcess = false;

	                      pEngine.confirm(pEngine.TRANSACTION.reference, pEngine.TRANSACTION.amount).then(function(reference) {
		                        pEngine._write('The transaction was confirmed, reference [' + reference + ']', 4);

	                            /* End polling
	                             *************/
		                      	pEngine._killPolling();

							    /* Populate transaction details
							     * and process the order
							     *******************************/
							    var params  = {
									       tender : 'CREDIT',
									       print : Sale.PRINT,
									       client_name : 'EMV SALE',
									       amt_paid : pEngine._returnCurrency(pEngine.RESPONSE.amount),
									       errcode : Sale.EMPTYSTR,
									       errmsg : Sale.EMPTYSTR,
									       auth_code : pEngine.RESPONSE.authCode,
									       trans_id : pEngine.RESPONSE.reference,
									       cardnumber : pEngine._removePan(pEngine.RESPONSE.panMasked),
									       expiredate : pEngine.RESPONSE.expireDate,
									       checknumber : Sale.EMPTYSTR,
									       card_type : pEngine.RESPONSE.cardType,
									       tip : Sale.EMPTYNUM,
									       emv : Sale.EMV,
									       track : Sale.EMPTYSTR
									     }

							    /* Shows an example on how to capture the results
							     * from Credit call and integrate with your own application.
							     ***********************************************************
							    //processOrder(params);

		                        /* Log the EMV details to cloud
		                         * THIS IS JUST AN EXAMPLE
		                         *******************************/
				                pEngine._post(Sale.base_path_model + 'json.emvlog.php', { reference : pEngine.RESPONSE.reference, amount : pEngine._returnCurrency(pEngine.RESPONSE.amount), transType : pEngine.RESPONSE.transType, cardType : pEngine.RESPONSE.cardType, cardName : 'EMV SALE', panMasked : pEngine._removePan(pEngine.RESPONSE.panMasked), result : pEngine.RESPONSE.result }, function() {
		                             pEngine._write('The transaction was successfully logged!', 4);

                                     /* Reset for next trans
                                      **********************/
	   	                             pEngine.reset();
				                });

	                      } ).catch(function(errmsg) { pEngine._write(errmsg, 3); });
                        }

                    } else {
                        pEngine._write('Transaction Cancelled', 3);
                        pEngine.reset();
	                    pEngine._killPolling();
                    }
				}
	        }
			catch(err) {
			    alert('Unregistered exception just occured in onTransactionFinished callback ' + err.message);
			}
        },
       onTransactionUpdate : function(sender, eventArgs) {
			try {

				pEngine._log(pEngine.RESPONSE_LOG, pEngine.EMPTY_PARAM, "onTransactionUpdate", eventArgs);

				if (pEngine._hasKeyValue("UPDATE", "CardRequested", eventArgs)) {
                   pEngine._write('Card requested from cardholder/Insert card now', 2);
				} else if (pEngine._hasKeyValue("UPDATE", "OnlineAuthRequested", eventArgs)) {
                   pEngine._write('Attempting credit card authorization', 2);
				} else if (pEngine._hasKeyValue("UPDATE", "OnlineAuthCompleted", eventArgs)) {
                   pEngine._write('Authorization Response received from host', 2);
				} else if (pEngine._hasKeyValue("UPDATE", "CardRemovalRequested", eventArgs)) {
                   pEngine._write('Please remove card from device', 3);
				} else if (pEngine._hasKeyValue("UPDATE", "AmountConfirmationStarted", eventArgs)) {
                   pEngine._write('Amount Confirmation Requested on device', 2);
				} else if (pEngine._hasKeyValue("UPDATE", "TippingRequested", eventArgs)) {
                   pEngine._write('Tipping requested on device', 2);
				} else if (pEngine._hasKeyValue("UPDATE", "TransactionStarted", eventArgs)) {
                   pEngine._write('Transaction has started on the device', 2);
				} else if (pEngine._hasKeyValue("UPDATE", "PinEntryStarted", eventArgs)) {
				   pEngine._state('Device Status has changed, Pin Entry has started', eventArgs);
                   pEngine._write(pEngine.NO_MSG, 2);
				} else if (pEngine._hasKeyValue("UPDATE", "ApplicationSelectionStarted", eventArgs)) {
				   pEngine._state('Device Status has changed, Application Selection has started', eventArgs);
                   pEngine._write(pEngine.NO_MSG, 2);
				} else if (pEngine._hasKeyValue("UPDATE", "Unknown", eventArgs)) {
				   pEngine._state('An Unknown Event has been triggered', eventArgs);
                   pEngine._write(pEngine.NO_MSG, 3);
				} else if (pEngine._hasKeyValue("UPDATE", "PanKeyEntryStarted", eventArgs)) {
				   pEngine._state('Device Status has changed, Pan Key Entry has started', eventArgs);
                   pEngine._write(pEngine.NO_MSG, 2);
				} else if (pEngine._hasKeyValue("UPDATE", "PanKeyEntryCompleted", eventArgs)) {
				   pEngine._state('Device Status has changed, Pan Key Entry has completed', eventArgs);
                   pEngine._write(pEngine.NO_MSG, 2);
				} else if (pEngine._hasKeyValue("UPDATE", "PanKeyEntryCompleted", eventArgs)) {
				   pEngine._state('Device Status has changed, Pan Key Entry has completed', eventArgs);
                   pEngine._write(pEngine.NO_MSG, 2);
				} else if (pEngine._hasKeyValue("UPDATE", "VoiceReferralCompleted", eventArgs)) {
				   pEngine._state('Device Status has changed, Voice Referral has completed', eventArgs);
                   pEngine._write(pEngine.NO_MSG, 2);
				}
				return false;
	        }
			catch(err) {
				pEngine._killPolling();
			    alert('Unregistered exception just occured in onTransactionUpdate callback, error is ' + err.message);
			}
        },
        onTransactionPaused : function(sender, eventArgs) {
			try {
                pEngine._log(pEngine.RESPONSE_LOG, pEngine.EMPTY_PARAM, "onTransactionPaused", eventArgs);
                pEngine._write('Transaction Paused', 3);
	        }
			catch(err) {
			    alert('Unregistered exception just occured in onTransactionPaused callback ' + err.message);
			}
        },
        onUpdateTransactionParametersFinished : function(sender, eventArgs) {
			try {
                pEngine._log(pEngine.RESPONSE_LOG, pEngine.EMPTY_PARAM, "onUpdateTransactionParametersFinished", eventArgs);
	        }
			catch(err) {
			    alert('Unregistered exception just occured in onUpdateTransactionParametersFinished callback ' + err.message);
			}
        },
        onCaptureReceipt : function(sender, eventArgs) {
			try {
	        }
			catch(err) {
			    alert('Unregistered exception just occured in onCaptureReceipt callback ' + err.message);
			}
	    },
        onCardNotification : function(sender, eventArgs) {
			try {
				pEngine._state('Device status has changed, Card has been NOTIFICATION', eventArgs);
	        }
			catch(err) {
			    alert('Unregistered exception just occured in onCardNotification callback ' + err.message);
			}
        },
        onCardDetails : function(sender, eventArgs) {
			try {
	            pEngine._log(pEngine.RESPONSE_LOG, pEngine.EMPTY_PARAM, "onCardDetails", eventArgs);
				pEngine._state('User action requested on device', eventArgs);
	        }
			catch(err) {
			    alert('Unregistered exception just occured in onCardDetails callback ' + err.message);
			}
        },
       onCredentialsFail : function(sender, eventArgs) {
			try {
	            pEngine._log(pEngine.RESPONSE_LOG, pEngine.EMPTY_PARAM, "onCredentialsFail", eventArgs);
                pEngine._write('pEngine, has returned that your credentials have been declined. Please correct and restart the program', 3);
	            pEngine._killPolling();
	        }
			catch(err) {
			    alert('Unregistered exception just occured in onCredentialsFail callback ' + err.message);
			}
        },
        onFinishedError : function(sender, eventArgs) {
			try {
                pEngine._write('Device status has changed, the card was removed prior to completing the transaction', 3);
	        }
			catch(err) {
			    alert('Unregistered exception just occured in onFinishedError callback ' + err.message);
			}
        },
	   /**
		 * This callback can be used to capture device status (Enabled/Disabled)
		 *
		 * @param {string} Callback
		 * @param {object} Details of event returned
		 * @return {void} callback function
		 */
        onPaymentDeviceAvailabilityChange : function(sender, eventArgs) {
			try {
				if (pEngine._hasKeyValue("IS_AVAILABLE", "True", eventArgs)) {
                   pEngine._write('Device Availability has changed, the device is now available for use and the pEngine service has been started', 1);
				} else if (pEngine._hasKeyValue("IS_AVAILABLE", "False", eventArgs)) {
                   pEngine._write('Device Availability has changed, the device is not connected or ready for use, pEngine service has been disabled. It will automatically start when the device is ready', 3);
			    }
	        }
			catch(err) {
			    alert('Unregistered exception just occured in onPaymentDeviceAvailabilityChange callback ' + err.message);
			}
        },
        onTmsUpdate : function(sender, eventArgs) {
			try {
	            pEngine._log(pEngine.RESPONSE_LOG, pEngine.EMPTY_PARAM, "onTmsUpdate", eventArgs);
	        }
			catch(err) {
			    alert('Unregistered exception just occured in onTmsUpdate callback ' + err.message);
			}
        },
        onError : function(sender, eventArgs) {
			try {
	            pEngine._log(pEngine.RESPONSE_LOG, pEngine.EMPTY_PARAM, "onError", eventArgs);
				pEngine._state('Device status is PaymentDeviceStatus<br />Platform Status is PaymentPlatformStatus', eventArgs);
	        }
			catch(err) {
			    alert('Unregistered exception just occured in onError callback ' + err.message);
			}
        },
        onChipDnaError : function(sender, eventArgs) {
			try {
	            pEngine._log(pEngine.RESPONSE_LOG, pEngine.EMPTY_PARAM, "onChipDnaError", eventArgs);
	        }
			catch(err) {
			    alert('Unregistered exception just occured in onChipDnaError callback ' + err.message);
			}
        },
        onSaleInitiated : function(sender, eventArgs) {
			try {
				pEngine._state('TransactionType initiated on device', eventArgs);
	        }
			catch(err) {
			    alert('Unregistered exception just occured in onSaleInitiated callback ' + err.message);
			}
        },
        onSetIdleMessage : function(sender, eventArgs) {
			try {
				pEngine._state('Idle message updated, SetIdleMessage', eventArgs);
	        }
			catch(err) {
			    alert('Unregistered exception just occured in onSetIdleMessage callback ' + err.message);
			}
        },
        onSaleStarted : function(sender, eventArgs) {
			try {
	            pEngine._log(pEngine.RESPONSE_LOG, pEngine.EMPTY_PARAM, "onSaleStarted", eventArgs);
	        }
			catch(err) {
			    alert('Unregistered exception just occured in onSaleStarted callback ' + err.message);
			}
        },
        onSaleConfirmed : function(sender, eventArgs) {
 			try {
                pEngine._log(pEngine.RESPONSE_LOG, pEngine.EMPTY_PARAM, "onSaleConfirmed", eventArgs);
            }
 			catch(err) {
 			    alert('Unregistered exception just occured in onSaleConfirmed callback ' + err.message);
 			}
        },
        onSaleRefunded : function(sender, eventArgs) {
 			try {
				pEngine._state('Transaction {Reference} was refunded ', eventArgs);
            }
 			catch(err) {
 			    alert('Unregistered exception just occured in onSaleRefunded callback ' + err.message);
 			}
        },
        onSaleVoided : function(sender, eventArgs) {
 			try {
				pEngine._state('Transaction {Reference} voided ', eventArgs);
            }
 			catch(err) {
 			    alert('Unregistered exception just occured in onSaleVoided callback ' + err.message);
 			}
        },
        onEnableTip : function(sender, eventArgs) {
 			try {
	            pEngine._log(pEngine.RESPONSE_LOG, pEngine.EMPTY_PARAM, "onEnableTip", eventArgs);
            }
 			catch(err) {
 			    alert('Unregistered exception just occured in onEnableTip callback ' + err.message);
 			}
        },
        onLogging : function() {
 			try {
	            pEngine._log(pEngine.RESPONSE_LOG, pEngine.EMPTY_PARAM, "onLogging", eventArgs);
            }
 			catch(err) {
 			    alert('Unregistered exception just occured in onLogging callback ' + err.message);
 			}
        },
        onTipAdjust : function(sender, eventArgs) {
 			try {
	            pEngine._log(pEngine.RESPONSE_LOG, pEngine.EMPTY_PARAM, "onTipAdjust", eventArgs);
            }
 			catch(err) {
 			    alert('Unregistered exception just occured in onTipAdjust callback ' + err.message);
 			}
        },
        onChangePassword : function(sender, eventArgs) {
 			try {
	            pEngine._log(pEngine.RESPONSE_LOG, pEngine.EMPTY_PARAM, "onChangePassword", eventArgs);
            }
 			catch(err) {
 			    alert('Unregistered exception just occured in onChangePassword callback ' + err.message);
 			}
        },
        onUnrecognizedSender : function(sender, eventArgs) {
 			try {
	            pEngine._log(pEngine.RESPONSE_LOG, pEngine.EMPTY_PARAM, "onUnrecognizedSender", eventArgs);
            }
 			catch(err) {
 			    alert('Unregistered exception just occured in onUnrecognizedSender callback ' + err.message);
 			}
        }
};
