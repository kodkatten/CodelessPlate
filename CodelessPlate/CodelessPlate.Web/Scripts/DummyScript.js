/// <reference path="stringformat.ts" />
var DummyScript;
(function (DummyScript) {
    var DummyClass = (function () {
        function DummyClass(document) {
            this.document = document;
            this.symbolIndex = 0;
        }
        DummyClass.prototype.AppendGreeting = function (greeting) {
            var _this = this;
            this.greetingString = "{0} " + greeting + " {0}";
            this.greetingDiv = document.createElement("div");
            this.greetingDiv.textContent = this.greetingString.format("-");
            this.document.body.appendChild(this.greetingDiv);

            setInterval(function () {
                var symbols = ["-", "/", "|", "\\"];

                _this.greetingDiv.textContent = _this.greetingString.format(symbols[_this.symbolIndex++]);

                _this.symbolIndex = _this.symbolIndex % 4;
            }, 333);
        };
        return DummyClass;
    })();
    DummyScript.DummyClass = DummyClass;
})(DummyScript || (DummyScript = {}));

window.onload = function () {
    var dummy = new DummyScript.DummyClass(document);
    dummy.AppendGreeting("This line is added with TypeScript");
};
//# sourceMappingURL=DummyScript.js.map
