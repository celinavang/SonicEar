const baseurl = "https://sonicear-backendapi.azure-api.net/sonicear/apiDevice/"

Vue.createApp({
    data() {
        return {
            item: null,
            errormessage: null,
            confirmationmessage: null,
            id: null,
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

                this.item = await response.data


            } catch (ex) {
                this.confirmationmessage = null
                this.errormessage = ex.message
            }
        },
        async editDevice() {
            try {
                const response = await axios.put(baseurl + this.item.id, this.item, {
                    headers: {
                        "Content-Type": "application/json",
                    }
                })
                if (response.status == "200") {
                    this.confirmationmessage = 'Enheden er blevet gemt.'
                    this.errormessage = null
                }
            } catch (ex) {
                this.confirmationmessage = null
                this.errormessage = ex.response.data
            }
            
        },
    }
}).mount("#app")