$('#BirthDate').datetimepicker({
    useCurrent: false,
    format: 'D/M/YYYY',
    maxDate: moment().subtract(18, 'years').format('l')
})