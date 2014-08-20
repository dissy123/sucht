(function () {
    debugger;
    if ($('#ContentPlaceHolder1_AsyncFileUpload1_ctl01') != null) {
        if ($('#ContentPlaceHolder1_AsyncFileUpload1_ctl01').html() == undefined) {
            $('#ContentPlaceHolder1_AsyncFileUpload1_ctl01').html('Datei auswählen!');
        } else {
            $('#ContentPlaceHolder1_AsyncFileUpload1_ctl01').html($('#ContentPlaceHolder1_AsyncFileUpload1_ctl01').html() + 'Datei auswählen!');
        }
    }
    
})();

(function () {
    debugger;
    if ($('#ContentPlaceHolder1_input_anhang_ctl01') != null) {
        if ($('#ContentPlaceHolder1_AsyncFileUpload1_ctl01').html() == undefined) {
            $('#ContentPlaceHolder1_input_anhang_ctl01').append(document.createTextNode('Datei auswählen!'));
        } else {
            $('#ContentPlaceHolder1_input_anhang_ctl01').append(document.createTextNode('Datei auswählen!'));
        }
    }

})();


var start;

(function () {
    start = new Date(Date.now());
    debugger;

    $("#input_stop_time").click(measure_time)
})();

function measure_time() {
    debugger;
    end = new Date(Date.now());
    end.setHours(end.getHours() - 1);
    $('#ContentPlaceHolder1_input_dauer')[0].value = new Date(end - start).toString().replace(/.*(\d{2}:\d{2}:\d{2}).*/, "$1");;
}