if (typeof ancestryAssistant === 'undefined')
	ancestryAssistant = {};

ancestryAssistant.postMessage = function (msgType, msgKey, payload) {
	var msg = {};
	msg.MessageType = msgType;
	msg.MessageKey = msgKey;
	msg.Payload = payload;
	console.log(msg);
	window.chrome.webview.postMessage(msg);
};

ancestryAssistant.getPerson = function () {
	var key = "";
	var rows = [];
	rows[0] = ["key", "value"];
	if (typeof(PersonCard) !== 'undefined') {
		key = PersonCard.personId;
		rows[1] = ["personId", PersonCard.personId];
		rows[2] = ["treeId", PersonCard.treeId];
		rows[3] = ["name", PersonCard.name];
		rows[4] = ["given", PersonCard.fullName.given];
		rows[5] = ["surname", PersonCard.fullName.surname];
		rows[6] = ["suffix", PersonCard.fullName.suffix];
		rows[7] = ["treeName", PersonCard.treeName];
		rows[8] = ["lifeYearRange", PersonCard.lifeYearRange];
		rows[9] = ["birthPlace", PersonCard.birthPlace];
		rows[10] = ["birthDate", PersonCard.birthDate];
		rows[11] = ["deathPlace", PersonCard.deathPlace];
		rows[12] = ["deathDate", PersonCard.deathDate];
		rows[13] = ["gender", PersonCard.gender];
		rows[14] = ["photo", PersonCard.photo];
		rows[15] = ["tabName", PersonCard.tabName];
	} else {
		rows[1] = ["personId", ""];
	}
  this.postMessage('person',key,rows);
};

ancestryAssistant.getState = function () {
	if (typeof (InitialState) !== 'undefined') {
		var state = JSON.parse(initialState.text);
		var trees = state.reduxInitialState.userTrees.sortedUserTrees;
	  var rows = [];
	  rows[0] = ["key", "value"];
		rows[1] = ["userId", state.reduxInitialState.user.uhomeUserProfile.userHandle];
		rows[2] = ["lastLoginDate", state.reduxInitialState.user.uhomeUserProfile.lastLoginDate];
		this.postMessage('initAccount', '', rows);

		rows = [];
		rows[0] = ["treeId", "Name", "LastModifiedDateTime", "lastViewedTree"];
		for (var r = 0; r < trees.length; r++)
			rows[r + 1] = [trees[r].Id.v, trees[r].Name, trees[r].LastModifiedDateTime, trees[r].lastViewedTree];
		this.postMessage('initTrees', '', rows);

	}
};


ancestryAssistant.getPage = function () {
	var rows = [];
	if (typeof (page_name) !== 'undefined') {
		rows[0] = page_name.replaceAll(' ', '').split(':');
	} else {
		rows[0] = location.hostname.split('.');
	}
	this.postMessage('page', '', rows);
};


ancestryAssistant.getTableData = function (personId) {
	var pid = personId;
	var pageTitle = document.getElementsByClassName('collectionTitle')[0].getElementsByTagName('a')[0].innerText;
	var pageNbr = document.getElementsByClassName('page-input')[0].value;
	var crow = [];
	var rows = [];
	var relationship = '';
	var f = 0;
	var L = document.getElementsByClassName('breadcrumbWrapper')[0].getElementsByClassName('pathText')

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
	this.postMessage('tableData', pid, rows);
};

