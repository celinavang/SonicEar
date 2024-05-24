const baseurl = "https://sonicear-backendapi.azure-api.net/sonicear/apiDevice/"
const measurementurl = "https://sonicear-backendapi.azure-api.net/sonicear/apiMeasurement/device="

Vue.createApp({
    data() {
        return {
            item: null,
            measurements: [],
            paginatedItems: [],
            errormessage: null,
            id: null,
            pageAmount: null,
            rowsPerPage: 6,
            currentPage: 1
            
        }
    },
    async created() {
        await this.getItems();
        await this.getMeasurements();
        if (this.measurements.length > 0) {
            this.pageAmount = Math.ceil(this.measurements.length / this.rowsPerPage)
            await this.DisplayList()
        }
        
    },
    methods: {
        async getItems() {
            try {
                const urlParams = new URLSearchParams(location.search)
                this.id = urlParams.get('id')

                const response = await axios.get(baseurl + urlParams.get('id'))
                

               
                this.item = await response.data
                

            } catch (ex) {
                this.errormessage = ex.message
            }
        },
        async getMeasurements() {
            try {
                const urlParams = new URLSearchParams(location.search)
                this.id = urlParams.get('id')
                const measurementresponse = await axios.get(measurementurl + urlParams.get('id'))
                this.measurements = await measurementresponse.data
            } catch (ex) {
                this.errormessage = ex.message
            }
        },
        async DisplayList() {
            let page = this.currentPage - 1;
            let start = this.rowsPerPage * page;
            let end = start + this.rowsPerPage;
            this.paginatedItems = this.measurements.slice(start, end);

        },

        setPage(number) {
            if (number < 1) number = 1;
            if (number > this.pageAmount) number = this.pageAmount;
            this.currentPage = number;
            this.DisplayList();
        },
        getColor(level) {
            if (level < 30) {
                return '#77c0e0'
            } else if (level < 0) {
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