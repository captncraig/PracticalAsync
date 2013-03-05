document.getElementById("impress").addEventListener( "impress:stepenter", function (event) {

    var step = event.target;
	var api = impress();
	if(step.id==='concurrency'){
		$(".word").removeClass('remain');
		$("#conc").css('opacity','1');
		api.next();
		$("#conc").animate({"font-size":"600%"},1000);
	}
	if(step.id==='synch'){
		$("#conc").css('opacity','0');
	}

}, false);