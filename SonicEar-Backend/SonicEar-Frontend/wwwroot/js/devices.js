const baseurl = "https://sonicear-backendapi.azure-api.net/sonicear/apiDevice"

Vue.createApp({
    data() {
        return {
            items: [],
            errormessage: null,
            currentSort: null,
            searchQuery: "",
            filteredItems: [],
            pageAmount: null,
            rowsPerPage: 10,
            currentPage: 1
        }
    },
    async created() {
        await this.getItems();
        this.pageAmount = Math.ceil(this.items.length / this.rowsPerPage)
        await this.DisplayList()
    },
    methods: {
        async getItems() {
            try {
                let response = await axios.get(baseurl)

                const urlParems = new URLSearchParams(location.search)

                if (urlParems.has('sortBy')) {
                    this.currentSort = urlParems.get('sortBy')
                    console.log(urlParems.get('sortBy'))
                    response = await axios.get(baseurl + '?sortBy=' + this.currentSort)
                }

                this.items = await response.data

            } catch (ex) {
                alert(ex.message)
            }
        },
        setSort(sortBy) {
            let sortParem = "";
            switch (sortBy) {

                case 'id':
                    if (this.currentSort == 'id_desc') return ''
                    else return '?sortBy=id_desc'
                    break;
                case 'location':
                    if (this.currentSort == 'location_desc') return '?sortBy=location_asc'
                    else return '?sortBy=location_desc'
                    break;
                default:
                    break;

			} 
        },
        searchDevices() {
            const query = this.searchQuery.toLowerCase();
            this.filteredItems = this.items.filter(item =>
                item.id.toString().includes(query) || 
                item.location.toLowerCase().includes(query)
            )
        },
        async DisplayList() {
            let page = this.currentPage - 1;
            let start = this.rowsPerPage * page;
            let end = start + this.rowsPerPage;
            let paginatedItems = this.items.slice(start, end);
            this.filteredItems = paginatedItems
        },
        setPage(number) {
            if (number < 1) number = 1;
            if (number > this.pageAmount) number = this.pageAmount;
            this.currentPage = number;
            this.DisplayList();
        },
        

    },
    computed: {
        top10() {
            return this.items.slice(1, 10)
        }
    },
}).mount("#app")