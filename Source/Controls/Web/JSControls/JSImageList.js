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