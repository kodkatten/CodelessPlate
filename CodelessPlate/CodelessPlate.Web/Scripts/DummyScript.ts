/// <reference path="stringformat.ts" />

 module DummyScript {

     export class DummyClass {
         private greetingString: string;
         private greetingDiv: HTMLDivElement;
         private symbolIndex: number = 0;

         constructor(private document: Document) {
         }

         public AppendGreeting(greeting: string) {
             this.greetingString = "{0} " + greeting + " {0}";
             this.greetingDiv = document.createElement("div");
             this.greetingDiv.textContent = this.greetingString.format("-");
             this.document.body.appendChild(this.greetingDiv);

             setInterval(() => {
                 var symbols: string[] = ["-", "/", "|", "\\"];

                 this.greetingDiv.textContent = this.greetingString.format(symbols[this.symbolIndex++]);

                 this.symbolIndex = this.symbolIndex % 4;
             }, 333);
         }
     }

}

window.onload = () => {
    var dummy = new DummyScript.DummyClass(document);
    dummy.AppendGreeting("This line is added with TypeScript");
};
