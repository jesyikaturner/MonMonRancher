mergeInto(LibraryManager.library, {
	OnAppLoaded: function () 
	{
		UnitySendMessage();
	}
});
