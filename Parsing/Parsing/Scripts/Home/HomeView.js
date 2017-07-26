var HomePage = {
    HomeView: function (inputParams) {
        this.ViewName = inputParams.viewName;
        this.ViewInstanceVariableName = inputParams.viewInstanceVariableName;
        this.PageId = inputParams.pageId;



        this.pageshow = function () {
            // Здесь обычно пишется код который будет выполнятся, когда подгрузилась html страника
        }


        this.GetParseData = function () {
            var methodName = "GetParseData";
            var errors = document.getElementById("Errors");

            var request = {};
            request.Url = $("#newUrl").val();
            if (request.Url == "") {
                errors.textContent = "Не заполнена ссылка";
                errors.style.color = "red";
                return;
            }
            request.TagCatalog = $("#TagCatalog").val();
            if (request.TagCatalog == "") {
                errors.textContent = "Не заполнен тег на блок товара";
                errors.style.color = "red";
                return;
            }
            request.TagName = $("#TagName").val();
            if (request.TagName == "") {
                errors.textContent = "Не заполнен тег на название товара";
                errors.style.color = "red";
                return;
            }
            request.TagParentImage = $("#TagImage").val();
            if (request.TagImage == "") {
                errors.textContent = "Не заполнен тег на картинку";
                errors.style.color = "red";
                return;
            }
            request.TagPrice = $("#TagPrice").val();
            if (request.TagPrice == "") {
                errors.textContent = "Не заполнен тег на цену";
                errors.style.color = "red";
                return;
            }
            request.TagDescription = $("#TagDescription").val();
            if (request.TagDescription == "") {
                errors.textContent = "Не заполнен тег на описание товара";
                errors.style.color = "red";
                return;
            }
            


            this.CallLoadData(methodName, JSON.stringify(request), function (result) {

                if (result == false) {
                    errors.textContent = "При обновлении произошла ошибка";
                    errors.style.color = "red";
                }
                if (result != false && result != true) {
                    errors.textContent = result;
                    errors.style.color = "red";
                }
                else {
                    errors.textContent = "Данные успешно распарсились";
                    errors.style.color = "green";
                }
            });
        }

        this.RedirectProduct = function () {
            var href = "/Home/List";
            window.location.reload(href);
        }

        this.RedirectHistory = function () {
            var href = "/History/History";
            window.location.reload(href);
        }

        this.CallLoadData = function (methodName, args, onsucces, onerror) {
            $.ajax({
                url: '/Home/' + methodName,
                type: "POST",
                async: true,
                cache: false,
                dataType: "json",
                data: "{'args':'" + args + "'}",
                contentType: "application/json; charset=utf-8",
                success: function (result) {
                    onsucces(result);
                },
                error: function (e) {
                    onerror(e);
                }
            });
        }
    }

}








