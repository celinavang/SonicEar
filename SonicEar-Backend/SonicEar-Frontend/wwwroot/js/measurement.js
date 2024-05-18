const baseurl = "https://sonicear-backendapi.azure-api.net/sonicear/apiMeasurement"

Vue.createApp({
    data() {
        return {
            items: [],
            errormessage: null,
        }
    },
    created() {
        this.getItems()
    },
    methods: {
        async getItems() {
            try {
                const response = await axios.get(baseurl)
                this.items = await response.data
            } catch (ex) {
                this.errormessage = ex.message
            }
        }
    }
}).mount("#app")