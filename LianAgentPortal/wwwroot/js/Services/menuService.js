menuService = {
    getAllMenu : function (userId, controllerName) {
        return $.ajax({
            url: "GetAllMenus",
            type: 'get',
            dataType: 'json',
            data: { userId: userId },
            contentType: 'application/json',
            success: function (data) {
                return data;
            }
        });
    }
}

