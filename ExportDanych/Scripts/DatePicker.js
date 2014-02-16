$(function () {
    $("#FromDate").datepicker({
        defaultDate: "+1w",
        changeMonth: true,
        changeYear: true,
        maxDate: "+0d",
        dateFormat: "yy-mm-dd",
        onClose: function (selectedDate) {
            $("#ToDate").datepicker("option", "minDate", selectedDate);
        }
    });
    $("#ToDate").datepicker({
        defaultDate: "+1w",
        changeMonth: true,
        changeYear: true,
        maxDate: "+0d",
        dateFormat: "yy-mm-dd",
        onClose: function (selectedDate) {
            $("#FromDate").datepicker("option", "maxDate", selectedDate);
        }
    });
});
