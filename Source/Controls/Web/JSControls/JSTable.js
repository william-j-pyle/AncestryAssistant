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