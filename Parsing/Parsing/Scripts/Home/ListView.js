var ListPage = {
    ListView: function (inputParams) {
        this.ViewName = inputParams.viewName;
        this.ViewInstanceVariableName = inputParams.viewInstanceVariableName;
        this.PageId = inputParams.pageId;



        this.pageshow = function () {
            // Здесь обычно пишется код который будет выполнятся, когда подгрузилась html страника
            this.GetData();

        }

        this.GetData = function () {
            var methodName = "GetData";

            var errors = document.getElementById("Errors");
            var divProduct = document.getElementById("productListBlock");
            
            this.CallLoadData(methodName, null, function (result) {
                if (result == false) {
                    errors.textContent = "При выборке произошла ошибка";
                    errors.style.color = "red";
                    return;
                }
                if (result.length != 0) {
                    result.forEach(function (item, i) {
                        var aBlock = document.createElement("a");
                        aBlock.href = "/Product/Product?Id=" + item.Id;
                        var divProductBlock = document.createElement("div");
                        divProductBlock.style.display = "inline-block";
                        divProductBlock.style.padding = "20px";
                        divProductBlock.style.width = "30%";
                        var pTitle = document.createElement("p");
                        pTitle.textContent = item.Name;
                        var imgDiv = document.createElement("img");
                        imgDiv.src = item.ImageUrl;
                        var divPrice = document.createElement("div");
                        divPrice.textContent = item.Price;
                        var divDescription = document.createElement("div");
                        divDescription.textContent = item.Descriptions;

                        divProductBlock.appendChild(pTitle);
                        divProductBlock.appendChild(imgDiv);
                        divProductBlock.appendChild(divPrice);
                        divProductBlock.appendChild(divDescription);
                        aBlock.appendChild(divProductBlock);

                        divProduct.appendChild(aBlock);
                    });
                }
            });
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








