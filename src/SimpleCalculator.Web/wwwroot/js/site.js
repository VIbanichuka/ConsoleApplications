$(document).ready(function () {
    _loadData(1);
});

function _loadData(page) {
    $.ajax({
        url: 'https://localhost:7278/api/calculator?page=' + page,
        type: "GET",
        success: function (result) {
            var object = '';
            $.each(result.calcResults, function (index, value) {
                object += '<tr>';
                object += '<td>' + value.id + '</td>';
                object += '<td>' + value.mathOperator + '</td>';
                object += '<td>' + value.firstNumber + '</td>';
                object += '<td>' + value.secondNumber + '</td>';
                object += '<td>' + value.result + '</td>';
                object += '</tr>';
            });

            $('#result_data').html(object);


            $("#pagination").html("");
            for (let i = 1; i <= result.totalPages; i++) {
                $("#pagination").append("<button onclick='_loadData(" + i + ")'>" + i + "</button>");
            }
        }
    });
}