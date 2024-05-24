const baseurl = "https://sonicear-backendapi.azure-api.net/sonicear/apiDevice/"

Vue.createApp({
    data() {
        return {
            location: null,
            errormessage: null,
            confirmationmessage: null
        }
    },
    methods: {
        async createNewDevice() {
            try {
                const response = await axios.post(baseurl, { "id": 0, "location": this.location }, {
                    headers: {
                        "Content-Type": "application/json",
                    }
                })
                if (response.status == "201") {
                    this.confirmationmessage = 'Enheden er blevet oprettet.'
                    this.errormessage = null
                    this.location= null
                    
                }
                
            } catch (ex) {
                console.log(ex.response)
                this.confirmationmessage = null
                this.errormessage = ex.response.data
            }
        }
    }
}).mount("#app")