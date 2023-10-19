window.AncestryAssistant = {
	captureFacts: function () {
		console.log('captureFacts');
		var item = document.getElementById("toggleSiblingsBtn");
		if (item != null) {
			if (item.getAttribute("aria-expanded") == 'false') {
				item.click();
			}
		}
			var evnt = {};
			evnt.MessageType = 'FactData';
			evnt.MessageKey = '';
		evnt.Payload = document.body.innerText;
			window.chrome.webview.postMessage(evnt);
	},
	captureFactsInternal: function () {
		console.log('captureFactsInternal');
		var evnt = {};
		evnt.MessageType = 'InternalFactData';
		evnt.Payload = document.body.innerText;
			evnt.MessageKey = '';
		window.chrome.webview.postMessage(evnt);
	},
	downloadImage: function () {
		console.log('downloadImage');
		var items = document.getElementsByClassName('iconTools calloutTrigger');
		if (items.length > 0) {
			items[0].click();
		}
		document.getElementsByClassName('iconDownload')[0].click();
		document.body.click();
	},
	captureCensus: function () {
		console.log('captureCensus');
		var items = document.getElementsByClassName('launchRecordTourContainer');
		if (items.length > 0) {
			items[0].remove();
		}
		var toggle = document.getElementsByClassName('indexToggle');
		if (toggle.length > 0) {
			if (!toggle[0].classList.contains('toggleActive')) {
				toggle[0].click();
			}
			var page = document.getElementsByClassName('page-input')[0].value;
			var evnt = {};
			evnt.MessageType = 'CensusData';
			evnt.MessageKey = page;
			evnt.Payload = document.body.innerText;
			window.chrome.webview.postMessage(evnt);
		}
	}
};

