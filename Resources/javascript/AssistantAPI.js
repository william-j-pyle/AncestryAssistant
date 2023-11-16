if (typeof ancestryAssistant === 'undefined')
	ancestryAssistant = {};

ancestryAssistant.MessageTypes = {};
ancestryAssistant.MessageTypes.MT_PERSON = 'person';
ancestryAssistant.MessageTypes.MT_ACCOUNT = 'account';
ancestryAssistant.MessageTypes.MT_TREES = 'trees';
ancestryAssistant.MessageTypes.MT_PAGE = 'page';
ancestryAssistant.MessageTypes.MT_TABLEDATA = 'tabledata';
ancestryAssistant.MessageTypes.MT_FINDAGRAVE = 'findagrave';

ancestryAssistant.postMessage = function (msgType, msgKey, payload) {
	var msg = {};
	msg.MessageType = msgType;
	msg.MessageKey = msgKey;
	msg.PageKey = '';
	msg.Payload = payload;
	console.log(msg);
	window.chrome.webview.postMessage(msg);
};

ancestryAssistant.getPerson = function () {
	var key = "";
	var hdr = [], dta = [];
	if (typeof(PersonCard) !== 'undefined') {
		key = PersonCard.personId;
		hdr.push("personId"); dta.push(PersonCard.personId);
		hdr.push("treeId"); dta.push(PersonCard.treeId);
		hdr.push("name"); dta.push(PersonCard.name);
		hdr.push("givenname"); dta.push(PersonCard.fullName.given);
		hdr.push("surname"); dta.push(PersonCard.fullName.surname);
		hdr.push("suffix"); dta.push(PersonCard.fullName.suffix);
		hdr.push("treeName"); dta.push(PersonCard.treeName);
		hdr.push("lifeYearRange"); dta.push(PersonCard.lifeYearRange);
		hdr.push("birthPlace"); dta.push(PersonCard.birthPlace);
		hdr.push("birthDate"); dta.push(PersonCard.birthDate);
		hdr.push("deathPlace"); dta.push(PersonCard.deathPlace);
		hdr.push("deathDate"); dta.push(PersonCard.deathDate);
		hdr.push("gender"); dta.push(PersonCard.gender);
		hdr.push("photo"); dta.push(PersonCard.photo);
		hdr.push("tabName"); dta.push(PersonCard.tabName);
		this.postMessage(this.MessageTypes.MT_PERSON,key,[hdr,dta]);
	}
};

ancestryAssistant.getState = function () {
	if (typeof (InitialState) !== 'undefined') {
		var state = JSON.parse(initialState.text);
		var trees = state.reduxInitialState.userTrees.sortedUserTrees;
		var hdr = [], dta = [];

		// Add Key(hdr)/Value(dta) entries
		hdr.push("USERID"); dta.push(state.reduxInitialState.user.uhomeUserProfile.userHandle);
		hdr.push("LASTLOGINDATE"); dta.push(state.reduxInitialState.user.uhomeUserProfile.lastLoginDate);
		// Send message
		this.postMessage(this.MessageTypes.MT_ACCOUNT, '', [hdr,dta]);

		var rows = [];
		// Add Header Rows
		rows.push(["TREEID", "NAME", "LASTMODIFIED", "ACTIVETREE"]);
		// Add Data Rows
		for (var r = 0; r < trees.length; r++)
			rows.push([trees[r].Id.v, trees[r].Name, trees[r].LastModifiedDateTime, trees[r].lastViewedTree]);
		// Send Message
		this.postMessage(this.MessageTypes.MT_TREES, '', rows);
	}
};

ancestryAssistant.getPage = function () {
	console.log("getPage");
	if (typeof (window.page_name) == 'undefined' && location.host=='www.ancestry.com')  {
		setTimeout(() => {ancestryAssistant.getPage();}, 2000);
		return;
	}
	console.log("getPage:Running");
	var rows = [];
	rows.push(['PAGEKEY']);

	if (typeof (window.page_name) !== 'undefined') {
		rows.push([window.page_name.replaceAll(' ', '')]);
	} else {
		rows.push([(location.hostname.replaceAll('.', ':') + location.pathname.replaceAll('/', ':')).replaceAll(' ', '')]);
	}
	this.postMessage(this.MessageTypes.MT_PAGE, '', rows);
};

ancestryAssistant.getTableData = function (personId) {
	var pid = personId;
	var pageTitle = document.getElementsByClassName('collectionTitle')[0].getElementsByTagName('a')[0].innerText;
	var pageNbr = document.getElementsByClassName('page-input')[0].value;
	var crow = [];
	var rows = [];
	var relationship = '';
	var f = 0;
	var L = document.getElementsByClassName('breadcrumbWrapper')[0].getElementsByClassName('pathText');

	for (var r = 0; r < document.getElementsByClassName('grid-row').length; r++) {
		var cells = document.getElementsByClassName('grid-row')[r].getElementsByClassName('grid-cell');
		crow = [];
		f = 0;
		if (r == 0) {
			crow[f] = 'Relationship'; f++;
			crow[f] = 'Title'; f++;
			crow[f] = 'PageNbr'; f++;
			for (var h = 0; h < L.length; h++) {
				crow[f] = 'BreadCrumb' + h; f++;
			}
			for (var h = 0; h < cells.length; h++) {
				crow[f] = cells[h].innerText; f++;
			}
		} else {
			if (document.getElementsByClassName('grid-row')[r].classList.contains('green-bg')) relationship = 'F';
			if (document.getElementsByClassName('grid-row')[r].classList.contains('yellow-bg')) relationship = 'P';
			if (document.getElementsByClassName('grid-row')[r].classList.contains('white-bg')) relationship = '';
			crow[f] = relationship; f++;
			crow[f] = pageTitle; f++;
			crow[f] = pageNbr; f++;
			for (var h = 0; h < L.length; h++) {
				crow[f] = L[h].innerText; f++;
			}
			for (var h = 0; h < cells.length; h++) {
				crow[f] = cells[h].innerText; f++;
			}
		}
		rows[r] = crow;
	}
	this.postMessage(this.MessageTypes.MT_TABLEDATA, pid, rows);
};

ancestryAssistant.getImage = function () {
	//Trigger the download
	var items = document.getElementsByClassName('iconTools calloutTrigger');
	if (items.length > 0) {
		items[0].click();
	}
	document.getElementsByClassName('iconDownload')[0].click();
	if (document.getElementsByClassName('saveToComputerDialog').length > 0) {
		document.getElementsByClassName('saveToComputerDialog')[0].getElementsByTagName('button')[0].click();
	}
	document.body.click();
};

ancestryAssistant.getFindAGrave = function () {
	var key = "";
	var hdr = [], dta = [];
	if (typeof (findagrave) == 'undefined') {
	  console.log("Waiting: FindAGrave object not yet loaded");
		setTimeout(() => { ancestryAssistant.getFindAGrave(); }, 2000);
		return;
	}
	console.log("Executing: getFindAGrave");
	if (typeof (findagrave) !== 'undefined') {
		console.log("Generating Message");
		hdr.push("memorialId"); dta.push(findagrave.memorialId);
		hdr.push("deathDate"); dta.push(findagrave.deathDate);
		hdr.push("cemeteryName"); dta.push(findagrave.cemeteryName);
		hdr.push("cemeteryCityName"); dta.push(findagrave.cemeteryCityName);
		hdr.push("cemeteryCountyName"); dta.push(findagrave.cemeteryCountyName);
		hdr.push("cemeteryStateName"); dta.push(findagrave.cemeteryStateName);
		hdr.push("cemeteryCountryAbbrev"); dta.push(findagrave.cemeteryCountryAbbrev);
		hdr.push("firstName"); dta.push(findagrave.firstName);
		hdr.push("lastName"); dta.push(findagrave.lastName);
		hdr.push("fullName"); dta.push(findagrave.fullName);
		hdr.push("birthYear"); dta.push(findagrave.birthYear);
		hdr.push("deathYear"); dta.push(findagrave.deathYear);
		hdr.push("deathMonth"); dta.push(findagrave.deathMonth);
		hdr.push("deathDay"); dta.push(findagrave.deathDay);
		hdr.push("locationName"); dta.push(findagrave.locationName);
		this.postMessage(this.MessageTypes.MT_FINDAGRAVE, key, [hdr, dta]);
	}
};