if (typeof ancestryAssistant === 'undefined')
  ancestryAssistant = {};

ancestryAssistant.MessageTypes = {};
ancestryAssistant.MessageTypes.MT_PERSON = 'person';
ancestryAssistant.MessageTypes.MT_ACCOUNT = 'account';
ancestryAssistant.MessageTypes.MT_TREES = 'trees';
ancestryAssistant.MessageTypes.MT_PAGE = 'page';
ancestryAssistant.MessageTypes.MT_TABLEDATA = 'tabledata';
ancestryAssistant.MessageTypes.MT_FINDAGRAVE = 'findagrave';
ancestryAssistant.MessageTypes.MT_FOCUSEVENT = 'focusevent';

// Add WebAPI Message Interface
ancestryAssistant.postMessage = function (msgType, msgKey, payload) {
  var msg = {};
  msg.MessageType = msgType;
  msg.MessageKey = msgKey;
  msg.PageKey = '';
  msg.Payload = payload;
  console.log(msg);
  window.chrome.webview.postMessage(msg);
};

ancestryAssistant.initAppHandlers = function () {
  window.addEventListener('click', function () {
    this.postMessage(this.MessageTypes.MT_FOCUSEVENT, "", "");
  });
};

// Capture the Ancestry.com person object, and post it back to the application
ancestryAssistant.getAncestryPerson = function () {
  var key = "";
  var hdr = [], dta = [];
  if (typeof (PersonCard) !== 'undefined') {
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
    this.postMessage(this.MessageTypes.MT_PERSON, key, [hdr, dta]);
  }
};

// Get the current state of the Ancestry page, results in 2 messages to application
ancestryAssistant.getAncestryState = function () {
  if (typeof (InitialState) !== 'undefined') {
    var state = JSON.parse(initialState.text);
    var trees = state.reduxInitialState.userTrees.sortedUserTrees;
    var hdr = [], dta = [], rows = [];

    // Message 1
    hdr.push("USERID"); dta.push(state.reduxInitialState.user.uhomeUserProfile.userHandle);
    hdr.push("LASTLOGINDATE"); dta.push(state.reduxInitialState.user.uhomeUserProfile.lastLoginDate);
    this.postMessage(this.MessageTypes.MT_ACCOUNT, '', [hdr, dta]);

    // Message 2
    rows.push(["TREEID", "NAME", "LASTMODIFIED", "ACTIVETREE"]);
    for (var r = 0; r < trees.length; r++)
      rows.push([trees[r].Id.v, trees[r].Name, trees[r].LastModifiedDateTime, trees[r].lastViewedTree]);
    this.postMessage(this.MessageTypes.MT_TREES, '', rows);
  }
};

// Get the current page information, if required objects are not available, it automatically waits and retrys
ancestryAssistant.getAncestryPage = function () {
  if (typeof (window.page_name) == 'undefined' && location.host == 'www.ancestry.com') {
    setTimeout(() => { ancestryAssistant.getPage(); }, 2000);
    return;
  }
  var rows = [];
  rows.push(['PAGEKEY']);
  if (typeof (window.page_name) !== 'undefined') {
    rows.push([window.page_name.replaceAll(' ', '')]);
  } else {
    rows.push([(location.hostname.replaceAll('.', ':') + location.pathname.replaceAll('/', ':')).replaceAll(' ', '')]);
  }
  this.postMessage(this.MessageTypes.MT_PAGE, '', rows);
};

// Reads and generates a message back to the app with the table data
// Any page that has a dropdown of details table, example Census
ancestryAssistant.getAncestryTableData = function (personId) {
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

// When on within the Ancestry Image/Media viewer, this function will trigger the image download
ancestryAssistant.triggerAncestryImageDownload = function () {
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

// Captures a person object from FindAGrave, and sends a message back to the app
ancestryAssistant.getFindAGravePerson = function () {
  var key = "";
  var hdr = [], dta = [];
  if (typeof (findagrave) == 'undefined') {
    setTimeout(() => { ancestryAssistant.getFindAGrave(); }, 2000);
    return;
  }
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

window.MyAncestryAPI = {
  ctlType: "",
  ctlKey: "",
  ctlDataSet: "",
  selectedRID: -1,
  selectedText: "",
  itemType: "none",
  itemCount: 0,
  itemVisibleCount: 0,
  filter: "",
  columnCount: 0,
  data: chrome.webview.hostObjects.sync.DataMgr,
  metadata: {},
  setControlFocus: function () { document.body.className = 'webcontrol hasfocus'; },
  removeControlFocus: function () { document.body.className = 'webcontrol'; },
  addDataHandlers: function () {
    chrome.webview.hostObjects.sync.DataMgr.addEventListener('DataChanged', function (dataSetName) {
      window.MyAncestryAPI.displayData(dataSetName);
    });
  },
  addEventHandlers: function (tag) {
    var tbody
    tbody = document.getElementById("gallery");
    Array.from(tbody.getElementsByTagName(tag)).forEach(function (item) {
      item.addEventListener('click', function () {
        var selectedRID = this.getAttribute("data-rid");
        document.querySelectorAll('.selected').forEach(function (sitem) { sitem.className = ""; });
        this.className = 'selected';
        window.MyAncestryAPI.selectedRID = selectedRID;
        if (window.MyAncestryAPI.data.selectedRID(window.MyAncestryAPI.ctlDataSet) != selectedRID) {
          window.MyAncestryAPI.data.SelectRowWeb(window.MyAncestryAPI.ctlDataSet, selectedRID);
        }
      });
    });
  },
  displayData: function (dataSetName) {
    var htm = "";
    var i, j;
    this.metadata = JSON.parse(this.data.getMetaDataWeb(dataSetName));
    htm += "<div id='gallery'>";
    for (i = 0; i < this.metadata.Rows; i++) {
      var dataRowObject = JSON.parse(this.data.getDataRowWeb(this.ctlDataSet, i));
      var RID = dataRowObject.RID;
      var dataRow = dataRowObject.data;
      htm += "<section data-rid='" + RID + "'>";
      htm += "<div><img src='" + dataRow[0] + "'></div><span>" + dataRow[1] + "</span>";
      htm += "</section>";
    }
    htm += "</div>";
    document.body.innerHTML = htm;
    this.addEventHandlers("section");
  },
  createControl: function (dataSetName) {
    this.ctlType = "WebControl";
    this.ctlDataSet = dataSetName;
    document.body.className = "webcontrol";
    this.displayData(dataSetName);
    this.addDataHandlers();
  },
  applyFilter: function (filterValue) {
    var filter, ol, li, i, txtValue;
    filter = filterValue.toUpperCase();
    ol = document.getElementById("gallery");
    li = ol.getElementsByTagName('tr');
    for (i = 0; i < li.length; i++) {
      txtValue = li[i].innerText
      if (txtValue.toUpperCase().indexOf(filter) > -1) {
        li[i].style.display = "";
      } else {
        li[i].style.display = "none";
      }
    }
    return true;
  },
  clearFilter: function () {
    var ol, li, i;
    ol = document.getElementById("dataset");
    li = ol.getElementsByTagName('tr');
    for (i = 0; i < li.length; i++) {
      li[i].style.display = "";
    }
    return true;
  },
  selectItem: function (RID) {
    if (window.MyAncestryAPI.selectedRID != RID) {
      window.MyAncestryAPI.selectedRID = RID;
      document.querySelectorAll('.selected').forEach(function (sitem) { sitem.className = ""; });
      document.querySelectorAll("tr[data-rid='" + RID + "']").forEach(function (sitem) { sitem.className = "selected"; });
    }
  }
};

window.MyAncestryAPI = {
  ctlType: "",
  ctlKey: "",
  ctlDataSet: "",
  selectedRID: -1,
  selectedText: "",
  itemType: "none",
  itemCount: 0,
  itemVisibleCount: 0,
  filter: "",
  columnCount: 0,
  data: chrome.webview.hostObjects.sync.DataMgr,
  metadata: {},
  setControlFocus: function () { document.body.className = 'webcontrol hasfocus'; },
  removeControlFocus: function () { document.body.className = 'webcontrol'; },
  addDataHandlers: function () {
    chrome.webview.hostObjects.sync.DataMgr.addEventListener('SelectionChangedWeb', function (dataSetName, selectedRID) {
      window.MyAncestryAPI.selectItem(selectedRID);
    });
  },
  addEventHandlers: function (tag) {
    var tbody
    tbody = document.getElementById("dataset");
    Array.from(tbody.getElementsByTagName(tag)).forEach(function (item) {
      item.addEventListener('click', function () {
        var selectedRID = this.getAttribute("data-rid");
        document.querySelectorAll('.selected').forEach(function (sitem) { sitem.className = ""; });
        this.className = 'selected';
        window.MyAncestryAPI.selectedRID = selectedRID;
        if (window.MyAncestryAPI.data.selectedRID(window.MyAncestryAPI.ctlDataSet) != selectedRID) {
          window.MyAncestryAPI.data.SelectRowWeb(window.MyAncestryAPI.ctlDataSet, selectedRID);
        }
      });
    });
  },
  createControl: function (dataSetName) {
    this.ctlType = "WebControl";
    this.ctlDataSet = dataSetName;
    var body = document.body;
    body.className = "webcontrol";
    var htm = "";
    var i, j;
    this.metadata = JSON.parse(this.data.getMetaDataWeb(dataSetName));
    htm += "<TABLE class='ColumnList'><THEAD>";
    for (i = 0; i < this.metadata.Columns.length; i++) {
      if (this.metadata.Columns[i].Visible == true) {
        htm += "<TH>" + this.metadata.Columns[i].Name + "</TH>";
      }
    }
    htm += "</THEAD><TBODY id='dataset'>";
    for (i = 0; i < this.metadata.Rows; i++) {
      var dataRowObject = JSON.parse(this.data.getDataRowWeb(this.ctlDataSet, i));
      var RID = dataRowObject.RID;
      var dataRow = dataRowObject.data;
      htm += "<TR data-rid=" + RID + ">";
      //array[0] is always the unique rowid of the datarow
      for (j = 0; j < this.metadata.Columns.length; j++) {
        if (this.metadata.Columns[j].Visible == true) {
          htm += "<TD>" + dataRow[j] + "</TD>";
        }
      }
      htm += "</TR>";
    }
    htm += "</TBODY></TABLE>";
    body.innerHTML = htm;
    this.addEventHandlers("tr");
    this.addDataHandlers();
  },
  applyFilter: function (filterValue) {
    var filter, ol, li, i, txtValue;
    filter = filterValue.toUpperCase();
    ol = document.getElementById("dataset");
    li = ol.getElementsByTagName('tr');
    for (i = 0; i < li.length; i++) {
      txtValue = li[i].innerText
      if (txtValue.toUpperCase().indexOf(filter) > -1) {
        li[i].style.display = "";
      } else {
        li[i].style.display = "none";
      }
    }
    return true;
  },
  clearFilter: function () {
    var ol, li, i;
    ol = document.getElementById("dataset");
    li = ol.getElementsByTagName('tr');
    for (i = 0; i < li.length; i++) {
      li[i].style.display = "";
    }
    return true;
  },
  selectItem: function (RID) {
    if (window.MyAncestryAPI.selectedRID != RID) {
      window.MyAncestryAPI.selectedRID = RID;
      document.querySelectorAll('.selected').forEach(function (sitem) { sitem.className = ""; });
      document.querySelectorAll("tr[data-rid='" + RID + "']").forEach(function (sitem) { sitem.className = "selected"; });
    }
  }
};

window.MyAncestryAPI = {
  ctlType: "",
  ctlKey: "",
  ctlDataSet: "",
  selectedRID: -1,
  selectedText: "",
  itemType: "none",
  itemCount: 0,
  itemVisibleCount: 0,
  filter: "",
  columnCount: 0,
  data: chrome.webview.hostObjects.sync.DataMgr,
  metadata: {},
  setControlFocus: function () { document.body.className = 'webcontrol hasfocus'; },
  removeControlFocus: function () { document.body.className = 'webcontrol'; },
  addDataHandlers: function () {
    chrome.webview.hostObjects.sync.DataMgr.addEventListener('SelectionChangedWeb', function (dataSetName, selectedRID) {
      window.MyAncestryAPI.selectItem(selectedRID);
    });
  },
  addEventHandlers: function (tag) {
    var tbody
    tbody = document.getElementById("dataset");
    Array.from(tbody.getElementsByTagName(tag)).forEach(function (item) {
      item.addEventListener('click', function () {
        var selectedRID = this.getAttribute("data-rid");
        document.querySelectorAll('.selected').forEach(function (sitem) { sitem.className = ""; });
        this.className = 'selected';
        window.MyAncestryAPI.selectedRID = selectedRID;
        if (window.MyAncestryAPI.data.selectedRID(window.MyAncestryAPI.ctlDataSet) != selectedRID) {
          window.MyAncestryAPI.data.SelectRowWeb(window.MyAncestryAPI.ctlDataSet, selectedRID);
        }
      });
    });
  },
  createControl: function (dataSetName) {
    this.ctlType = "WebControl";
    this.ctlDataSet = dataSetName;
    var body = document.body;
    body.className = "webcontrol webtable";
    var htm = "";
    var i, j;
    this.metadata = JSON.parse(this.data.getMetaDataWeb(dataSetName));
    htm += "<TABLE class='TableList'><THEAD>";
    for (i = 0; i < this.metadata.Columns.length; i++) {
      if (this.metadata.Columns[i].Visible == true) {
        var minWidth = this.metadata.Columns[i].MinWidth * 8;
        htm += "<TH style='min-width:" + minWidth + "px'>" + this.metadata.Columns[i].Name + "</TH>";
      }
    }
    htm += "</THEAD><TBODY id='dataset'>";
    for (i = 0; i < this.metadata.Rows; i++) {
      var dataRowObject = JSON.parse(this.data.getDataRowWeb(this.ctlDataSet, i));
      var RID = dataRowObject.RID;
      var dataRow = dataRowObject.data;
      htm += "<TR data-rid=" + RID + ">";
      //array[0] is always the unique rowid of the datarow
      for (j = 0; j < this.metadata.Columns.length; j++) {
        if (this.metadata.Columns[j].Visible == true) {
          htm += "<TD>" + dataRow[j] + "</TD>";
        }
      }
      htm += "</TR>";
    }
    htm += "</TBODY></TABLE>";
    body.innerHTML = htm;
    this.addEventHandlers("tr");
    this.addDataHandlers();
  },
  applyFilter: function (filterValue) {
    var filter, ol, li, i, txtValue;
    filter = filterValue.toUpperCase();
    ol = document.getElementById("dataset");
    li = ol.getElementsByTagName('tr');
    for (i = 0; i < li.length; i++) {
      txtValue = li[i].innerText
      if (txtValue.toUpperCase().indexOf(filter) > -1) {
        li[i].style.display = "";
      } else {
        li[i].style.display = "none";
      }
    }
    return true;
  },
  clearFilter: function () {
    var ol, li, i;
    ol = document.getElementById("dataset");
    li = ol.getElementsByTagName('tr');
    for (i = 0; i < li.length; i++) {
      li[i].style.display = "";
    }
    return true;
  },
  selectItem: function (RID) {
    if (window.MyAncestryAPI.selectedRID != RID) {
      window.MyAncestryAPI.selectedRID = RID;
      document.querySelectorAll('.selected').forEach(function (sitem) { sitem.className = ""; });
      document.querySelectorAll("tr[data-rid='" + RID + "']").forEach(function (sitem) { sitem.className = "selected"; });
    }
  }
};