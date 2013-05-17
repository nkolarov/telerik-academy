function attachEventHandler(element,eventType,eventHandler){
	if(!element){
		return;
	}

    if(document.addEventListener){
        element.addEventListener(eventType,eventHandler,false);
    }
    else if(document.attachEvent){
        element.attachEvent("on" + eventType,eventHandler);
    }
    else{
        element['on' + eventType] = eventHandler;
    }
}