# Ancestry Data Capture

## Login

On Initial connect, navigate to:

	https://www.ancestry.com/account/signin

If Already logged in, will automatically forward to home:

	https://www.ancestry.com/

Regardless of URL result, perform the following steps:

If ```initialState==undefined``` then login should be required
	if document.getElementByID("username")!=undefined and document.getElementByID("password")!=undefined
		If user.hasCredentials==false then UserLoginDialog.show()
	document.getElementByID("username").value=user.userName
	document.getElementByID("password").value=user.password
	document.getElementByID("signInBtn").click()