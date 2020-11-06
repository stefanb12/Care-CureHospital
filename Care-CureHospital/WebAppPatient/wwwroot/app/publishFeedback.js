Vue.component("publishFeedback", {
	data: function (){
		return {
			patientFeedbacks: [],
			text: '',
			isAnonymous: false,
			isForPublishing: false
		}
	},
	template:`
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
		        <a href="">Registruj se</a>
	            <a href="">Prijavi se</a>
		    </div>
	    </div>
	 </div>
	 
	<div class="formForPublishingFeedback">
                 <div class="form-title">
                     <h1>Ostavite utisak</h1>
                          <br><br>
						<input type="text" v-model="text" placeholder="Ostavite Vas utisak...">                 											

						<input type="checkbox" id="isAnonymous" name="isAnonymous" value="isAnonymous" v-model = "isAnonymous">
						<label for="vehicle1"> Anonimno</label><br>
						<input type="checkbox" id="isForPublishing" name="isForPublishing" value="isForPublishing" v-model = "isForPublishing">
						<label for="vehicle2">Dozvoli objavljivanje</label><br>	
			
                         <div class="post-feedback-btn">
                             <button type="button" @click="postFeedback">Posalji</button>
                         </div>



                     </form>
                 </div>
             </div>

	 <div class="verticalLine"></div>
	
	 <div class="sideComponents">      
	     <ul class="ulForSideComponents">
		    <div><li><a href="#/patientsFeedbacks">Svi utisci</a></li></div><br/>
		    <div><li><a href="#/">Objavljeni utisci</a></li></div><br/>
			<div><li class="active" ><a href="#/publishFeedback">Ostavite utisak</a></li></div><br/>
	     </ul>
	 </div>
	 
		 


	 <div class="titleForPublishedFeedbackPreview">
		 <h1>Utisci pacijenata</h1>
	 </div> 
		 

	 <div class="listOfFeedbacks">
		 
	 <div v-for="pf in patientFeedbacks" >	
	 	 
		<div class="wrapper">
		    <div class="feedback-img">
		        <img src="./pictures/comment.png" height="150" width="150" style="margin-left: 20%; margin-top: 14%;">
		    </div>
		    <div class="feedback-info">
		        <div class="feedback-text">
		            <h1 v-if="pf.isAnonymous === true">Anonimni pacijent</h1>
					<h1 v-else ></h1> <!-- OBRISAN: {{pf.patient.Name}} {{pf.patient.Surname}} -->
		            <h2></h2>
					<h3></h3>
					<div  style="overflow-y:scroll;height:100px;width:450px;">
						{{pf.text}}
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
		postFeedback: function () {
			axios.post('/api/patientFeedback', {
				text: this.text,
				isForPublishing: this.isForPublishing,
				isPublished: false,
				isAnonymous: this.isAnonymous,
				patientID: 1,
				patient: null,
				publishingDate: "0001-01-01T00:00:00"
			});
		}	
			
		},
	mounted(){

		axios.get('api/patientFeedback/getPublishedFeedbacks').then(response => {
			this.patientFeedbacks = response.data;
		});	
	
	}
	
});