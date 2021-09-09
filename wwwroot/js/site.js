$('form input, form select').on('change keyup', CheckValid);

function CheckValid() {
    // Check passwords
    var enabled = $('#password').val() == $('#confirm').val();

    $('#warning').html(enabled ? '' : 'Passwords do not match');

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

    // Implement numeric imput in text boxes, dissalowing continuation if the value is not a number
    $('form input.numeric:visible').each(function () {
        if (!jQuery.isNumeric($(this).val())) {
            enabled = false;
        }
    })

    $('#submit').prop('disabled', !enabled);
}