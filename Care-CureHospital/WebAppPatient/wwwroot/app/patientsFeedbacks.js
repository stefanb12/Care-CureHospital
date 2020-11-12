Vue.component("patientsFeedbacks", {
	data: function () {
		return {
			patientFeedbacks: [],
			typeOfFeedback: 'Svi utisci'
		}
	},
	template: `
	<div>
	
	 <div class="boundaryForScroll">
	     <div class="logoAndName">
	         <div class="logo">        
	             <img src="pictures/clinic.png"/>
	         </div>
	         <div class="webName">
	             <h3></h3>
	         </div>  
	     </div>
	 
	     <div class="main">     
	         <ul class="menu-contents">
	            <li  class="active"><a href="#/">Utisci pacijenata</a></li>
	         </ul>
	     </div>
 
	     <div class="dropdown">
	        <button class="dropbtn">
	        	<img id="menuIcon" src="pictures/menuIcon.png" />
	        	<img id="userIcon" src="pictures/user.png" />
	        </button>
		    <div class="dropdown-content">
		        <a >Registruj se</a>
	            <a >Prijavi se</a>
		    </div>
	    </div>
	 </div>

	 
	<div class="filterFeedbacks">
            <div class="form-title">
                <h1>Filtriraj utiske pacijenata:</h1>
                <select v-model="typeOfFeedback">
                <option value="Svi utisci" selected>Svi utisci</option>
                <option value="Utisci za objavljivanje">Utisci za objavljivanje</option>
                </select>
		    </div>
     </div>
	 

	 <div class="verticalLine"></div>
	
	 <div class="sideComponents">      
	     <ul class="ulForSideComponents">
			<div><li><a href="#/">Objavljeni utisci</a></li></div><br/>
		    <div><li class="active"><a href="#/patientsFeedbacks">Svi utisci</a></li></div><br/>
			<div><li><a href="#/postFeedback">Ostavite utisak</a></li></div><br/>
	     </ul>
	 </div>
	 		 

	<!--
	 <div class="titleForPublishedFeedbackPreview">
		 <h1>Utisci pacijenata</h1>
	 </div> 
	-->	 
		 

	 <div class="listOfFeedbacks">
		 
	 <div v-for="pf in filterPatientFeedbacks" >	
 	 
		<div class="wrapper">
		    <div class="feedback-img">
		        <img src="./pictures/comment.png" height="150" width="150" style="margin-left: 20%; margin-top: 14%;">
		    </div>
		    <div class="feedback-info">
		        <div class="feedback-text">
		            <h1 v-if="pf.isAnonymous === true">Anonimni pacijent</h1>
					<h1 v-else >{{pf.patient}}</h1> 
		            <p>{{pf.publishingDate}}</p>
					<h3></h3>
					<div  style="overflow-y:scroll;height:100px;width:460px;border:1px solid;padding: 10px 10px 15px 10px;">
						{{pf.text}}
					</div>
					<div v-if="pf.isForPublishing === true && pf.isPublished === false" class="publishFeedback-btn">
                            <button type="button" @click="publishFeedback(pf)">Podeli javno</button>
					</div>
					<div v-else-if="pf.isForPublishing === true && pf.isPublished === true" class="publishFeedbackParagraph1">
                            <p>Utisak je objavljen</p>
					</div>
					<div v-else-if="pf.isForPublishing === false && pf.isPublished === false" class="publishFeedbackParagraph2">
                            <p>Utisak nije moguće objaviti</p>
					</div>
		         </div>
			</div>
	     </div>		
	 </div>
	<!--
	<template v-if="!patientFeedbacks || !patientFeedbacks.length"> 
		<div  class="emptyListOfFeedbacks">
			<h2 >Trenutno nema utisaka pacijenata!</h2>
		</div>
	</template >
	-->

	 </div>		     
		  
	</div>
        
	`
	,
	methods: {
		publishFeedback: function (patientFeedback) {
			axios.put('api/patientFeedback/publishFeedback/' + patientFeedback.id)
				.then(response => {
					axios.get('api/patientFeedback').then(response => {
						toast('Utisak je uspešno objavljen!')
						this.patientFeedbacks = response.data;
					});
					$this.router.go();
				});
		}
	},
	computed: {
		filterPatientFeedbacks() {
			if (this.typeOfFeedback === "Svi utisci") {
				return this.patientFeedbacks.filter(feedback => {
					return feedback.isForPublishing === true || feedback.isForPublishing === false
				});
			} else if (this.typeOfFeedback === "Utisci za objavljivanje") {
				return this.patientFeedbacks.filter(feedback => {
					return feedback.isForPublishing === true && feedback.isPublished === false
				});
			}
		}
	},
	mounted() {

		axios.get('api/patientFeedback').then(response => {
			this.patientFeedbacks = response.data;
		});

	}

});