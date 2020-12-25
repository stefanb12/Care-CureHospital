Vue.component("patientMainPage", {
	data: function () {
		return {
            slideIndex: 1
		}
	},
	template: `
	<div>
	
	  <div class="slideshow-container">

      <div class="mySlides fade">
        <div class="numbertext">1 / 3</div>
        <img src="" style="width:1000px; height:200px;">
        <div class="text"></div>
      </div>

      <div class="mySlides fade">
        <div class="numbertext">2 / 3</div>
        <img src="" style="width:100%" style="width:1000px; height:200px;">
        <div class="text"></div>
      </div>

      <div class="mySlides fade">
        <div class="numbertext">3 / 3</div>
        <img src="" style="width:100%" style="width:1000px; height:200px;">
        <div class="text"></div>
      </div>

      <a class="prev" @click="plusSlides(-1)">&#10094;</a>
      <a class="next" @click="plusSlides(1)">&#10095;</a>

      </div>
      <br>

    <div style="text-align:center">
        <span class="dot" @click="currentSlide(1)"></span>
        <span class="dot" @click="currentSlide(2)"></span>
        <span class="dot" @click="currentSlide(3)"></span>
    </div>
	 	  
	</div>
        
    `   
    ,
	components : {
		
    }
    ,
    computed : {	
				
	},
	methods: {
         showSlides: function(n) {
            var i;
            var slides = document.getElementsByClassName("mySlides");
            var dots = document.getElementsByClassName("dot");
            if(n > slides.length) { this.slideIndex = 1 }
            if (n < 1) { this.slideIndex = slides.length }
            for (i = 0; i < slides.length; i++) {
                slides[i].style.display = "none";
            }
            for (i = 0; i < dots.length; i++) {
                dots[i].className = dots[i].className.replace(" dot-active", "");
            }
            slides[this.slideIndex - 1].style.display = "block";
            dots[this.slideIndex - 1].className += " dot-active";
        },
        plusSlides: function(n) {
            this.showSlides(this.slideIndex += n);
        },
        currentSlide: function(n) {
            this.showSlides(this.slideIndex = n);
        }
               
	},
	mounted() {
        this.showSlides(this.slideIndex);
	}
});