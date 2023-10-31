sampleCodeService = {
    uploadFile: function (file) {
        var data = new FormData();
        data.append('file', file);
        return $.ajax({
            url: '/api/SampleCode/FileUpload',
            type: 'POST',
            data: data,
            processData: false,
            contentType: false,
            success: function (data) {
                return data;
            }
        });
    }
}