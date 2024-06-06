mergeInto(LibraryManager.library, {
    Hello: function() {
        window.bionWorldPopup("GedungBion");
    },

    HelloString: function(str) {
        window.bionWorldPopup(Pointer_stringify(str));
    },
});