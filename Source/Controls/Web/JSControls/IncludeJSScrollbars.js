document.addEventListener('DOMContentLoaded', function () {
  var x = document.createElement('STYLE');
  x.appendChild(document.createTextNode('::-webkit-scrollbar {width: 14px;background-color: #2e2e2e;}'));
  x.appendChild(document.createTextNode('::-webkit-scrollbar-corner {background-color: #2e2e2e;}'));
  x.appendChild(document.createTextNode('::-webkit-scrollbar-thumb {width: 14px;border-color: #2e2e2e;border-style: solid;border-size: .5px;background-color: #4d4d4d;}'));
  x.appendChild(document.createTextNode('::-webkit-scrollbar-thumb:hover {width: 14px;border-color: #2e2e2e;border-style: solid;border-size: .5px;background-color: #cccccc;}'));
  x.appendChild(document.createTextNode('::-webkit-scrollbar-track {background-color: #2e2e2e;}'));
  //x.appendChild(document.createTextNode('::-webkit-scrollbar-button {background-color: #2e2e2e; height: 16px !important;}'));
  x.appendChild(document.createTextNode('::-webkit-scrollbar-button:horizontal:increment:end:hover {height: 16px !important;background-color: #cccccc;background-repeat:no-repeat;background-position:center;background-image: url(../img/ico_20_scrollbar_right.png);}'));
  x.appendChild(document.createTextNode('::-webkit-scrollbar-button:horizontal:decrement:start:hover {height: 16px !important;background-color: #cccccc;background-repeat:no-repeat;background-position:center;background-image: url(../img/ico_20_scrollbar_left.png);}'));
  x.appendChild(document.createTextNode('::-webkit-scrollbar-button:vertical:increment:end:hover {height: 16px !important;background-color: #cccccc;background-repeat:no-repeat;background-position:center;background-image: url(../img/ico_20_scrollbar_down.png);}'));
  x.appendChild(document.createTextNode('::-webkit-scrollbar-button:vertical:decrement:start:hover {height: 16px !important;background-color: #cccccc;background-repeat:no-repeat;background-position:center;background-image: url(../img/ico_20_scrollbar_up.png);}'));

  x.appendChild(document.createTextNode('::-webkit-scrollbar-button:horizontal:increment:end {background-color: #2e2e2e; height: 16px !important;background-repeat:no-repeat;background-position:center;background-image: url(../img/ico_20_scrollbar_right_default.png);}'));
  x.appendChild(document.createTextNode('::-webkit-scrollbar-button:horizontal:decrement:start {background-color: #2e2e2e; height: 16px !important;background-repeat:no-repeat;background-position:center;background-image: url(../img/ico_20_scrollbar_left_default.png);}'));
  x.appendChild(document.createTextNode('::-webkit-scrollbar-button:vertical:increment:end {background-color: #2e2e2e; height: 16px !important;background-repeat:no-repeat;background-position:center;background-image: url(../img/ico_20_scrollbar_down_default.png);}'));
  x.appendChild(document.createTextNode('::-webkit-scrollbar-button:vertical:decrement:start {background-color: #2e2e2e; height: 16px !important;background-repeat:no-repeat;background-position:center;background-image: url(../img/ico_20_scrollbar_up_default.png);}'));
  x.appendChild(document.createTextNode('#BannerRegion {display:none;}'));
  x.appendChild(document.createTextNode('#HeaderRegion {display:none;}'));
  document.head.appendChild(x);
});