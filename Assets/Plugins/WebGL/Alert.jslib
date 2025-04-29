mergeInto(LibraryManager.library, {
    Hello: function() {
        window.bionWorldPopup("binusSyahdan");
    },

    HelloString: function(str) {
        window.bionWorldPopup(Pointer_stringify(str));
    },
});