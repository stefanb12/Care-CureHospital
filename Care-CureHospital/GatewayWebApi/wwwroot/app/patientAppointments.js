Vue.component("patientAppointments", {
	data: function () {
		return {
			filterAppointments: 'Svi pregledi',
			scheduledAppointments: [],
			previousAppointments: [],
			userToken: null,
			loggedUserId: 0
		}
	},
	template: `
	<div>	
	<div class="boundaryForScrollAppointments">
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
				<li class="active"><a href="#/patientAppointments">Pregledi</a></li>
				<li><a href="#/">Utisci</a></li>
				<li><a href="#/patientMainPage">Početna</a></li>
				<li><a href="#/medicalRecordReview">Moj karton</a></li>
				<li><a href="#/patientDocumentsSimpleSearch">Dokumenti</a></li>
	         </ul>
	     </div>
 
	     <div class="dropdown">
	        <button class="dropbtn">
	        	<img id="menuIcon" src="images/menuIcon.png" />
	        	<img id="userIcon" src="images/user.png" />
	        </button>
		    <div class="dropdown-content">
		        <a href="#/userLogin" @click="logOut()">Odjavi se</a>
		    </div>
	    </div>
	 </div>
	 
	<div class="filterAppointments">
            <div class="form-title-appointments">
                <h1>Filtriraj preglede:</h1>
                <select v-model="filterAppointments" @change="onChange()">>
					<option value="Svi pregledi" selected>Svi pregledi</option>
					<option value="Zakazani pregledi">Zakazani pregledi</option>
					<option value="Pregledi na kojima sam bio">Pregledi na kojima sam bio</option>
                </select>
		    </div>
     </div>

	 <div class="verticalLine"></div>
	
	 <div class="sideComponents">      
		 <ul class="ulForSideComponents">
		 <div><li class="active"><a href="#/patientAppointments">Moji pregledi</a></li></div><br/>
         <div><li><a href="#/appointmentSchedulingStandard" @click="clickSchedulingStandard()">Obično zakazivanje</a></li></div><br/>
         <div><li><a href="#/appointmentSchedulingByRecommendation">Preporuka termina</a></li></div><br/>
	     </ul>
	 </div> 	

	<div class="listOfAppointments">		 
		<div v-for="appointment in previousAppointments">	
			<div class="wrapper-appointments">
				<div class="appointments-img">
					<img src="./images/previousAppointment.png" height="150" width="150" style="margin-left: 20%; margin-top: 14%;">
				</div>
				<div class="appointments-info">
					<div class="appointments-text">
						<h1>Dr {{appointment.doctorFullName}}</h1> 
						<h3>- {{appointment.doctorSpecialization}}</h3>
						<h3 style="margin-top:8px"><i>Ordinacija:</i> {{appointment.room}}</h3>
						<h3 style="margin-top:8px"><i>Vreme:</i> {{appointment.period}}</h3>
						<p>{{appointment.date}}</p>
						<div class="cancelAppointment-btn">
							<button type="button" @click="fillSurvey(appointment)">Popuni anketu</button>
							<div class="documents-btn">
							<button type="button" @click="displayReport(appointment.medicalExaminationId)">Izveštaj</button>
							</div>	
							<div class="prescriptionss-btn">
								<button type="button" @click="displayPrescription(appointment.medicalExaminationId)">Recept</button>
							</div>	
						</div>	
						<!--<div v-if="appointment.surveyFilled === true" class="appointmentsParagraph1">
							<p>Popunili ste anketu</p>
						</div>-->					
					</div>
				</div>		
			</div>
		</div>	
		<div v-for="appointment in scheduledAppointments">	
			<div class="wrapper-appointments">
				<div class="appointments-img">
					<img src="./images/scheduledAppointment.png" height="150" width="150" style="margin-left: 20%; margin-top: 14%;">
				</div>
				<div class="appointments-info">
					<div class="appointments-text">
						<h1>Dr {{appointment.doctorFullName}}</h1> 
						<h3>- {{appointment.doctorSpecialization}}</h3>
						<h3 style="margin-top:8px"><i>Ordinacija:</i> {{appointment.room}}</h3>
						<h3 style="margin-top:8px"><i>Vreme:</i> {{appointment.period}}</h3>
						<p>{{appointment.date}}</p>
						<div class="cancelAppointment-btn">
							<button type="button" @click="cancelAppointment(appointment.id)" id="cancelAppointmentButton">Otkaži pregled</button>
						</div>
						<!--<div v-if="appointment.canceled === true" class="appointmentsParagraph2">
							<p>Otkazali ste ovaj pregled</p>
						</div>-->
					</div>
				</div>		
			</div>
		</div>	
	</div>

	</div>
        
	`
	,
	methods: {
		cancelAppointment: function (appointmentId) {
			axios.put('gateway/appointment/cancelAppointment/' + appointmentId, null, {
				headers: {
					'Authorization': 'Bearer ' + this.userToken
				}
			}).then(response => {
				if (response.status !== 204) {
					axios.get('gateway/appointment/getScheduledAppointmetsByPatient/' + this.loggedUserId, {
						headers: {
							'Authorization': 'Bearer ' + this.userToken
						}
					}).then(response => {
						toast('Uspešno ste otkazali pregled')
						this.scheduledAppointments = response.data;
					});
				} else {
					toast('Rok za otkazivanje pregleda je prošao')
                }					
			}).catch(error => {
				if (error.response.status === 401 || error.response.status === 403) {
					toast('Nemate pravo pristupa stranici!')
					this.$router.push({ name: 'userLogin' })
				}
			});
		},

		fillSurvey: function (selectedAppointment) {
			if (selectedAppointment.surveyFilled === true) {
				toast('Već ste popunili anketu za ovaj pregled')
			} else {
				this.$router.push({ name: 'surveyAfterExamination', params: { appointment: selectedAppointment } })
            }		
		},

		displayReport: function (medicalExaminationId) {
			axios.get('/gateway/medicalExaminationReport/getMedicalExaminationReportByMedicalExaminationId/' + medicalExaminationId, {
				headers: {
					'Authorization': 'Bearer ' + this.userToken
				}
			}).then(response => {
				var reportForAppointment = response.data
				this.$router.push({ name: 'reportForAppointment', params: { report: reportForAppointment } })

			}).catch(error => {
				if (error.response.status === 404) {
					toast('Ne postoji izveštaj za ovaj pregled!')
				}
				if (error.response.status === 401 || error.response.status === 403) {
					toast('Nemate pravo pristupa stranici!')
					this.$router.push({ name: 'userLogin' })
				}
			});
		},

		displayPrescription: function (medicalExaminationId) {
			axios.get('/gateway/prescription/getPrescriptionByMedicalExaminationId/' + medicalExaminationId, {
				headers: {
					'Authorization': 'Bearer ' + this.userToken
				}
			}).then(response => {
				var prescriptionForAppointment = response.data
				this.$router.push({ name: 'prescriptionForAppointment', params: { prescription: prescriptionForAppointment } })

			}).catch(error => {
				if (error.response.status === 404) {
					toast('Ne postoji recept za ovaj pregled!')
				}
				if (error.response.status === 401 || error.response.status === 403) {
					toast('Nemate pravo pristupa stranici!')
					this.$router.push({ name: 'userLogin' })
				}
			});
		},

		onChange: function () {
			if (this.filterAppointments === "Svi pregledi") {
				axios.get('gateway/appointment/getScheduledAppointmetsByPatient/' + this.loggedUserId, {
					headers: {
						'Authorization': 'Bearer ' + this.userToken
					}
				}).then(response => {
					this.scheduledAppointments = response.data;
					axios.get('gateway/appointment/getPreviousAppointmetsByPatient/' + this.loggedUserId, {
						headers: {
							'Authorization': 'Bearer ' + this.userToken
						}
					}).then(response => {
						this.previousAppointments = response.data;
					});
				}).catch(error => {
					axios.get('gateway/appointment/getPreviousAppointmetsByPatient/' + this.loggedUserId, {
						headers: {
							'Authorization': 'Bearer ' + this.userToken
						}
					}).then(response => {
						this.previousAppointments = response.data;
					});
				});
			} else if (this.filterAppointments === "Zakazani pregledi") {
				axios.get('gateway/appointment/getScheduledAppointmetsByPatient/' + this.loggedUserId, {
					headers: {
						'Authorization': 'Bearer ' + this.userToken
					}
				}).then(response => {
					this.scheduledAppointments = response.data;
					this.previousAppointments = []
				}).catch(error => {
					this.previousAppointments = []
				});
			} else if (this.filterAppointments === "Pregledi na kojima sam bio") {
				axios.get('gateway/appointment/getPreviousAppointmetsByPatient/' + this.loggedUserId, {
					headers: {
						'Authorization': 'Bearer ' + this.userToken
					}
				}).then(response => {
					this.previousAppointments = response.data;
					this.scheduledAppointments = []
				}).catch(error => {
					this.scheduledAppointments = []
				});		
            }
		},
		logOut: function () {
			localStorage.removeItem("validToken");
		},
		clickSchedulingStandard: function() {
			
        }
	},
	computed: {
		
	},
	mounted() {
		this.userToken = localStorage.getItem('validToken');

		if (this.userToken !== null) {
			var base64Url = this.userToken.split('.')[1];
			var base64 = base64Url.replace(/-/g, '+').replace(/_/g, '/');
			var jsonPayload = decodeURIComponent(atob(base64).split('').map(function (c) {
				return '%' + ('00' + c.charCodeAt(0).toString(16)).slice(-2);
			}).join(''));

			this.decodedToken = JSON.parse(jsonPayload);
			this.loggedUserId = parseInt(this.decodedToken.unique_name);
		}

		axios.get('gateway/appointment/getScheduledAppointmetsByPatient/' + this.loggedUserId, {
			headers: {
				'Authorization': 'Bearer ' + this.userToken
			}
		}).then(response => {
			this.scheduledAppointments = response.data;
			axios.get('gateway/appointment/getPreviousAppointmetsByPatient/' + this.loggedUserId, {
				headers: {
					'Authorization': 'Bearer ' + this.userToken
				}
			}).then(response => {
				this.previousAppointments = response.data;
				axios.get('gateway/patient/getPatient/' + this.loggedUserId, {
					headers: { 'Authorization': 'Bearer ' + this.userToken }
				}).then(response => {
					this.patient = response.data;
				}).catch(error => {
					if (error.response.status === 401 || error.response.status === 403) {
						toast('Nemate pravo pristupa stranici!')
						this.$router.push({ name: 'userLogin' })
					}
				});
			}).catch(error => {
				if (error.response.status === 401 || error.response.status === 403) {
					toast('Nemate pravo pristupa stranici!')
					this.$router.push({ name: 'userLogin' })
				}
			});		
		}).catch(error => {
			if (error.response.status === 404) {
				axios.get('gateway/appointment/getPreviousAppointmetsByPatient/' + this.loggedUserId, {
					headers: {
						'Authorization': 'Bearer ' + this.userToken
					}
				}).then(response => {
					this.previousAppointments = response.data;
				}).catch(error => {
					if (error.response.status === 401 || error.response.status === 403) {
						toast('Nemate pravo pristupa stranici!')
						this.$router.push({ name: 'userLogin' })
					}
				});		
			}
		});
	}

});