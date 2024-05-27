const deviceurl = "https://sonicear-backendapi.azure-api.net/sonicear/apiDevice"
const measurementurl = "https://sonicear-backendapi.azure-api.net/sonicear/apiMeasurement"

Vue.createApp({
    data() {
        return {
            devices: [],
            measurements: [],
            errormessage: null,
            currentSort: null,
        }
    },
    async created() {
        await this.getDevices()
        await this.getMeasurements()
    },
    methods: {
        async getDevices() {
            try {
                response = await axios.get(deviceurl)
                this.devices = await response.data


            } catch (ex) {
                alert(ex.message)
            }
        },
        async getMeasurements() {
            try {
                response = await axios.get(measurementurl +"?SortBy=date"  )
                this.measurements = await response.data
            } catch (ex) {
                alert(ex.message)
            }
        },
        getColor(level) {
            if (level < 30) {
                return '#77c0e0'
            } else if (level < 50) {
                return '#3fa5b1'
            } else if (level < 60) {
                return '#54a383'
            } else if (level < 75) {
                return '#66a15d'
            } else if (level < 80) {
                return '#9bbb66'
            } else if (level < 90) {
                return '#ffc454'
            } else if (level < 100) {
                return '#f8ad3a'
            } else if (level < 115) {
                return '#e77f38'
            } else if (level < 130) {
                return '#e2682d'
            } else {
                return '#d95139'
            }
        },
    }
        
}).mount("#app")