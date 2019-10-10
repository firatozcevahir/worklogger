$('#deleteConfirmModal').on('shown.bs.modal', function (e) {
    $triggerBtn = $(e.relatedTarget);
    $('#hddnItemId').val($triggerBtn.data('item-id'));
    $('#spnItemDescription').html($triggerBtn.data('item-description'));
});