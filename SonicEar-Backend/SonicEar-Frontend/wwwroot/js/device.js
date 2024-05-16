const baseurl = "https://sonicear-backendapi.azure-api.net/sonicear/apiDevice"

Vue.createApp({
    data() {
        return {
            currentPage: 1,
            items: [],
            errormessage: null,
            title: null,
            detail: null
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