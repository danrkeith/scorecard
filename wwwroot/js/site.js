$('form input, form select').on('change keyup', CheckValid);

function CheckValid() {
    var enabled = true;

    // Check passwords
    if ($('#confirm').length == 1) {
        if ($('#password').val() != $('#confirm').val()) {
            enabled = false;
        }
        $('#warning').html(enabled ? '' : 'Passwords do not match');
    }

    // Check  if fields are filled
    $('form input:visible, form select:visible').each(function () {
        if ($(this).val() == "") {
            enabled = false;
        }
    });

    // FiveHundred: Check if tricks are possible
    var sum = 0;
    $('form select.defendingTricks:visible').each(function () {
        sum += +$(this).val();
    });
    if (sum > 10) {
        enabled = false;
    }

    // If there are numeric text boxes, only allow continuation if they are numbers
    $('form input.numeric:visible').each(function () {
        if (!jQuery.isNumeric($(this).val())) {
            enabled = false;
        }
    })

    $('#submit').prop('disabled', !enabled);
}