roleService = {
    get: function (id, controllerName) {
        return $.ajax({
            url: "GetRoleById",
            data: { id: id },
            dataType: "json",
            success: function (data) {
                return data;
            }
        });
    },
    addOrUpdate: function (role, controllerName) {
        return $.ajax({
            url: "AddOrUpdateRole",
            type: 'post',
            //dataType: 'json',
            data: JSON.stringify(role),
            contentType: 'application/json',
            success: function () {

            }
        });
    }
}