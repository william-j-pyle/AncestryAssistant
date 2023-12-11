# Required Components

* AncestryViewer
  * Manages Login to Ancestry.com
  * Presents Website via WebView2
  * Provides NavigateTo method for all common Ancestry links
    * Internally tracks treeID, and activeAncestor making it possible to jump from point to point
    * NavigateTo also accepts optional AncestorID to quickly jump to any person on your tree externally controled
  * Provides Data Parsers for User Information and Images
* CensusViewer
  * Census data returned by AncestryViewer is stored locally
  * Census data can be viewed offline in an Excel like interface
  * Census Images are also available offline for viewing
  * All captured Census Years can be viewed individually, or in a combined common format
  * When Census data is captured, it is tagged for Year, Page, the row with the Ancestors data, and the rows for the household
* NotesViewer
  * Provides a lite One Note style interface
  * Allows for text formatting
  * Accepts Web cut/paste
  * Accepts images
  * Every Ancestor Has there own unique NotesViewer data file. But each data file can contain one or more pages of information similar to One Note
* GalleryViewer
  * Provides a list of Image thumbnails saved from Web, or added locally for an Ancestor
  * If Image is captured via Ancestry, then all details are captured too
  * A fullsize image view is also available, and provides the following features
    * Pan/Zoom
    * Image Modifications
      * While some editing can be done in the viewer, the original image is never modified, all steps taken to make the changes are stored in a config file.
      * Available Edits
        * Resize
        * Crop
        * Brightness/Contract
        * Hue/Saturation
        * Tilt