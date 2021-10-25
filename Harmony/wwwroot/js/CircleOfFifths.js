// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.


// Write your JavaScript code.

var CHORD_COLLECTION = {
    "C": [{ "positions": ["x", "3", "2", "0", "1", "0"], "fingerings": [["0", "3", "2", "0", "1", "0"]] }, { "positions": ["x", "3", "5", "5", "5", "3"], "fingerings": [["0", "1", "2", "3", "4", "1"]] }, { "positions": ["x", "3", "2", "0", "1", "3"], "fingerings": [["0", "3", "2", "0", "1", "4"]] }, { "positions": ["8", "10", "10", "9", "8", "8"], "fingerings": [["1", "3", "4", "2", "1", "1"]] }, { "positions": ["8", "7", "5", "5", "5", "8"], "fingerings": [["3", "2", "1", "1", "1", "4"]] }, { "positions": ["8", "7", "5", "5", "8", "x"], "fingerings": [["3", "2", "1", "1", "4", "0"]] }, { "positions": ["8", "7", "x", "x", "8", "8"], "fingerings": [["2", "1", "0", "0", "3", "4"]] }, { "positions": ["x", "3", "2", "x", "5", "3"], "fingerings": [["0", "2", "1", "0", "4", "3"]] }, { "positions": ["x", "3", "2", "5", "x", "3"], "fingerings": [["0", "2", "1", "4", "0", "3"]] }, { "positions": ["8", "7", "x", "9", "8", "x"], "fingerings": [["2", "1", "0", "4", "3", "0"]] }, { "positions": ["x", "15", "14", "12", "13", "12"], "fingerings": [["0", "4", "3", "1", "2", "1"]] }, { "positions": ["x", "15", "17", "17", "17", "15"], "fingerings": [["0", "1", "2", "3", "4", "1"]] }, { "positions": ["20", "22", "22", "21", "20", "20"], "fingerings": [["1", "3", "4", "2", "1", "1"]] }, { "positions": ["x", "x", "10", "12", "13", "12"], "fingerings": [["0", "0", "1", "2", "4", "3"]] }, { "positions": ["8", "7", "10", "x", "8", "x"], "fingerings": [["2", "1", "4", "0", "3", "0"]] }, { "positions": ["20", "19", "17", "17", "17", "20"], "fingerings": [["3", "2", "1", "1", "1", "4"]] }, { "positions": ["x", "15", "14", "x", "13", "15"], "fingerings": [["0", "3", "2", "0", "1", "4"]] }, { "positions": ["20", "19", "17", "17", "20", "x"], "fingerings": [["3", "2", "1", "1", "4", "0"]] }, { "positions": ["x", "15", "14", "12", "x", "15"], "fingerings": [["0", "3", "2", "1", "0", "4"]] }, { "positions": ["20", "19", "x", "x", "20", "20"], "fingerings": [["2", "1", "0", "0", "3", "4"]] }, { "positions": ["x", "15", "14", "x", "17", "15"], "fingerings": [["0", "2", "1", "0", "4", "3"]] }, { "positions": ["x", "15", "14", "17", "x", "15"], "fingerings": [["0", "2", "1", "4", "0", "3"]] }, { "positions": ["20", "19", "x", "21", "20", "x"], "fingerings": [["2", "1", "0", "4", "3", "0"]] }, { "positions": ["20", "19", "22", "x", "20", "x"], "fingerings": [["2", "1", "4", "0", "3", "0"]] }]
}


var checkBox = $('#switchToGuitarChordsCheckbox');
var slider = $('#switchToGuitarChords');
var sliderOnOf = 0;

slider.on('click', function () {
    if (sliderOnOf == 0) {
        $('#switchToGuitarChordsCheckbox').prop('checked', true);
        sliderOnOf = 1;
    } 
});



$('.buttonus').on('click', function () {
    $('.harmonies-container')[0].innerHTML = '';

    $.ajax({
        type: 'GET',
        url: 'https://localhost:44383/api/CircleOfFifthsAPI?' + 'scale=' + $('#scale option:selected').text().trim() + '&' + 'numberOfChords=' + $('#numberOfChords option:selected').text() + '&' + 'isMagic=' + $('#isMagic option:selected').val(),
        dataType: 'json',
        data: {
            numberOfChords: $('#numberOfChords option:selected').text(),
            scale: $('#scale option:selected').text(),
            isMagic: $('#isMagic option:selected').val()
        },
        success: function (data) {

            if (checkBox.is(':checked') == false) {
                data.forEach(harmony => {
                    var harmonyContainer = "";

                    harmonyContainer += '<div class="harmony-container">';
                    harmonyContainer += '<div class="chord-body">';

                    harmony.chords.forEach(chord => {
                        harmonyContainer += '<p class="chord" style="display: inline; font-size:8em">';
                        harmonyContainer += chord;
                        harmonyContainer += '</p>'
                    });

                    harmonyContainer += '</div>';

                    harmonyContainer += '<div class="favorite-button" style="width: 45px; height: 45px; margin-left: 970px; margin-top: -94px;">';
                    harmonyContainer += '<a onclick=" Swal.fire(';
                    harmonyContainer += "'Sweet!',";
                    harmonyContainer += "'You have added the Harmony to your favorites!',";
                    harmonyContainer += "'success'";
                    harmonyContainer += ')"><img src="/Images/star.png" alt="" style="width:45px; height:45px" /></a>';
                    harmonyContainer += '</div>';
                    harmonyContainer += '</div>';

                    $('.harmonies-container')[0].innerHTML += harmonyContainer;


                });
            }

        },
        error: function (ex) {
            var r = jQuery.parseJSON(response.responseText);
            alert("Message: " + r.Message);
            alert("StackTrace: " + r.StackTrace);
            alert("ExceptionType: " + r.ExceptionType);
        }
    });

})
