window.addEventListener('click', function () {
  var evnt = {};
  evnt.ControlKey = "";
  evnt.EventName = "WindowClick";
  evnt.DataSetName = "";
  evnt.EventArg = "";
  window.chrome.webview.postMessage(evnt);
});