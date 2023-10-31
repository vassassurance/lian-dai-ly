userService = {
    getUser: function (id) {
        return $.ajax({
            url: "GetUserById",
            data: { id: id },
            dataType: "json",
            success: function (data) {
                return data;
            }
        });
    },
    addOrUpdate: function (user) {
        return $.ajax({
            url: "AddOrUpdateUser",
            type: 'post',
            //dataType: 'json',
            data: JSON.stringify(user),
            contentType: 'application/json',
            success: function () {}
        });
    }
}