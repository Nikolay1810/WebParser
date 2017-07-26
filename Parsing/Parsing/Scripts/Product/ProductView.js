var ProductPage = {
    ProductView: function (inputParams) {
        this.ViewName = inputParams.viewName;
        this.ViewInstanceVariableName = inputParams.viewInstanceVariableName;
        this.PageId = inputParams.pageId;



        this.pageshow = function () {
            // Здесь обычно пишется код который будет выполнятся, когда подгрузилась html страника
            var pageUrl = document.URL;
            var productId = this._GetParametrFromUrl(pageUrl, 'Id');
            if (productId != "") {
                this.GetProductById(productId);
            }
        }


        this.GetProductById = function (productId) {
            var methodName = "GetProductById";
            var request = {};
            request.Id = productId
            var divProduct = document.getElementById("productBlock");
            this.CallLoadData(methodName, JSON.stringify(request), function (result) {
                if (result != null) {
                    var divProductBlock = document.createElement("div");
                    var pTitle = document.createElement("p");
                    pTitle.textContent = result.Name;
                    var imgDiv = document.createElement("img");
                    imgDiv.src = result.ImageUrl;
                    var divPrice = document.createElement("div");
                    divPrice.innerHTML = result.Price;
                    var divDescription = document.createElement("div");
                    divDescription.textContent = result.Descriptions;

                    divProductBlock.appendChild(pTitle);
                    divProductBlock.appendChild(imgDiv);
                    divProductBlock.appendChild(divPrice);
                    divProductBlock.appendChild(divDescription);

                    divProduct.appendChild(divProductBlock);
                }
            });
        }

        this.CallLoadData = function (methodName, args, onsucces, onerror) {
            $.ajax({
                url: '/Product/' + methodName,
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

        this._GetParametrFromUrl = function (locationString, name) {
            name = name.replace(/[\[]/, '\\\[').replace(/[\]]/, '\\\]');
            var regexS = '[\\?&]' + name + '=([^&#]*)';
            var regex = new RegExp(regexS);
            var results = regex.exec(locationString);
            if (results == null)
                return '';
            else
                return decodeURIComponent(results[1].replace(/\+/g, ' '));
        }
    }
}








