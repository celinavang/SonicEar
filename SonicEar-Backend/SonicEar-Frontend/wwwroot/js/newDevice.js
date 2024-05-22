const baseurl = "https://sonicear-backendapi.azure-api.net/sonicear/apiDevice/"

Vue.createApp({
    data() {
        return {
            location: '',
            response: ''
        }
    },
    methods: {
        async createNewDevice() {
            try {
                const res = await axios.post(baseurl, { "id": 0, "location": this.location }, { headers: { "Content-Type": "application/json", } });
                this.response = `Succes: ${res.data.message}`;
            } catch (error) {
                this.response = `Error: ${error.response ? error.response.data.message : error.message}`;
            }
        }
    }
}).mount("#app")