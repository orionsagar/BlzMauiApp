let mybutton = document.getElementsByClassName("btn-back-to-top");

// When the user clicks on the button, scroll to the top of the document
//mybutton.addEventListener("click", backToTop);
function backToTop() {
    console.log("hello");
  document.body.scrollTop = 0;
  document.documentElement.scrollTop = 0;
}

//for (let i = 0; i < mybutton.length; i++) {
//    mybutton[i].addEventListener("click", function () {
//        console.log("Clicked index: " + i);
//        document.body.scrollTop = 0;
//        document.documentElement.scrollTop = 0;
//    });
//}


//const boxes = document.querySelectorAll('.backtotop');

//boxes.forEach(box => {
//    box.addEventListener('click', function handleClick(event) {
//        console.log('box clicked', event);
//        document.body.scrollTop = 0;
//        document.documentElement.scrollTop = 0;
//        //box.setAttribute('style', 'background-color: yellow;');
//    });
//});



//var userSelection = document.getElementsByClassName('backtotop');

//for (let i = 0; i < userSelection.length; i++) {
//    userSelection[i].addEventListener("click", function () {
//        console.log("Clicked index: " + i);
//        document.body.scrollTop = 0;
//        document.documentElement.scrollTop = 0;
//    });
//}


//const Nextelement = document.getElementById("btnNext");
//Nextelement.addEventListener("click", myFunction);

//const Prevelement = document.getElementById("btnPrev");
//Prevelement.addEventListener("click", myFunction);

//function myFunction() {
//    console.log("Clicked index: ");
//    document.body.scrollTop = 0;
//    document.documentElement.scrollTop = 0;
//}