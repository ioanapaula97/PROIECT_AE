window.Order = (function ($) {

    let editUrl = "/ProductType/Edit/{0}";
    let deleteUrl = "/ProductType/Delete/{0}"

    function _getCartItemsByIds() {

        let selectedId = getSelectedId();

        $.ajax({
            url: stringFormat(deleteUrl, selectedId),
            data: { "id": selectedId },
            type: "delete",
            success: function (data) {
                if (data.success)
                    $(jid(selectedId)).remove();
            },
            error: function (context, status, message) {
                alert(context, status, message);
            }
        });

    }


    return {
        getCartItemsByIds: _getCartItemsByIds
    }

}($));