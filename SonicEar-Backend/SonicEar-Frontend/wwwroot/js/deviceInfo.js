const baseurl = "https://sonicear-backendapi.azure-api.net/sonicear/apiDevice/"
const measurementurl = "https://sonicear-backendapi.azure-api.net/sonicear/apiMeasurement/device="

Vue.createApp({
    data() {
        return {
            item: null,
            measurements: [],
            errormessage: null,
            id: null
        }
    },
    created() {
        this.getItems()
    },
    methods: {
        async getItems() {
            try {
                const urlParams = new URLSearchParams(location.search)
                this.id = urlParams.get('id')

                const response = await axios.get(baseurl + urlParams.get('id'))
                const measurementresponse = await axios.get(measurementurl + this.id)

                this.item = await response.data
                this.measurements = await measurementresponse.data
                

            } catch (ex) {
                this.errormessage = ex.message
            }
        }
    }
}).mount("#app")