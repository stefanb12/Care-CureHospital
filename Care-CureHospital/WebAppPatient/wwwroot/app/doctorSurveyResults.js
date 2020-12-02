Vue.component("doctorSurveyResults", {
	data: function () {
		return {
            doctorSurveyResults: [],
            doctorQuestionsAverageGrades: []
		}
	},
	template: `
	<div>
	
	<div class="boundaryForScrollSurvey">
	     <div class="logoAndName">
	         <div class="logo">        
	             <img src="images/hospital.png"/>
	         </div>
	         <div class="webName">
	             <h3></h3>
	         </div>  
	     </div>
	 
	     <div class="main">     
	         <ul class="menu-contents">
				<li><a href="#/">Pretraga dokumenata</a></li>
				<li class="active"><a href="#/">Anketa</a></li>
	         </ul>
	     </div>
 
	     <div class="dropdown">
	        <button class="dropbtn">
	        	<img id="menuIcon" src="images/menuIcon.png" />
	        	<img id="userIcon" src="images/user.png" />
	        </button>
		    <div class="dropdown-content">
		        <a >Registruj se</a>
	            <a >Prijavi se</a>
		    </div>
		</div>
		
	<div class="survey-vertical-line"></div>
	
    <div class="sideComponents">      
    <ul class="ulForSideComponents">
       <div><li style="margin-left : 30px"><a href="#/surveyResults">Opšti rezultati</a></li></div><br/>
       <div><li style="margin-left : 30px" class="active"><a href="#/doctorSurveyResults">Rezultati za doktore</a></li></div><br/>
    </ul>
    </div>  

	
    <div class="survey-questions">
    <template v-for = "(doctorResult, index) in doctorSurveyResults">
        <h3 class = "doctor-name-and-specialitation">dr {{doctorResult.doctor.name}} {{doctorResult.doctor.surname}}</h3>
        <h3 class = "doctor-name-and-specialitation">Specijalizacija: {{doctorResult.doctor.specialitation.specialitationForDoctor}}</h3>

		<table class="questions-about-doctor" style="margin-bottom : 40px">
			<tr>
			<th style="min-width:430px;">Pitanja</th>
			<th style="min-width:90px;">Vrlo loše</th>
			<th style="min-width:90px;">Loše</th>
			<th style="min-width:90px;">Dobro</th>
			<th style="min-width:90px;">Vrlo dobro</th>
			<th style="min-width:90px;">Odlično</th>
			<th style="min-width:90px;">Prosek</th>
			</tr>
			<tr>
            <td>Ljubaznost doktora prema pacijentu</td>
            <template v-for="grade in doctorResult.questionResults[0].grades">
			    <td>{{grade}}</td>
            </template>
            <td>{{doctorResult.questionResults[0].averageGrade}}</td>
			</tr>
			<tr>
			<td>Posvećenost doktora pacijentu</td>
			<template v-for="grade in doctorResult.questionResults[1].grades">
			    <td>{{grade}}</td>
            </template>
            <td>{{doctorResult.questionResults[1].averageGrade}}</td>
			</tr>
			<tr>
			<td>Pružanje informacija od strane doktora o mom zdravstvenom stanju i mogućnostima lečenja</td>
			<template v-for="grade in doctorResult.questionResults[2].grades">
			    <td>{{grade}}</td>
            </template>
            <td>{{doctorResult.questionResults[2].averageGrade}}</td>
            </tr>
            <tr>
				<td></td>
				<td></td>
				<td></td>
				<td></td>
                <td></td>
                <td></td>
				<td>{{doctorQuestionsAverageGrades[index].toFixed(2)}}</td>
			</tr>
		</table> 
	</template>

	</div>
	
	 
	 

	     
	</div>	  
	</div>
        
	`
	,
	methods: {

	},
	computed: {

	},
	mounted() {

		axios.get('api/survey/getSurveyResultsForDoctors').then(response => {
                    this.doctorSurveyResults = response.data;
                    for (var doctorResult of this.doctorSurveyResults) {
                        var averageGradePerDoctor = (doctorResult.questionResults[0].averageGrade 
                            + doctorResult.questionResults[1].averageGrade + doctorResult.questionResults[2].averageGrade) / 3;
                        this.doctorQuestionsAverageGrades.push(averageGradePerDoctor);
                    }
				});

       
	}

});