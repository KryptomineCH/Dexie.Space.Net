using Dexie.Space.Net.Offers_NS;
using Dexie.Space.Net.Offers_NS.Objects_NS;
using Dexie.Space.Net.Offers_NS.Response_NS;
using Nito.AsyncEx;

namespace Dexie.Space.Net_UnitTests.Offers_NS
{
    public class Offers_Functions
    {
        [Fact]
        public void TestPostOfferSync()
        {
            // Arrange
            string offer = "offer1qqzh3wcuu2rykcmqvpsxygqqwc7hynr6hum6e0mnf72sn7uvvkpt68eyumkhelprk0adeg42nlelk2mpagr90qq0a37v8lc9h9kwwafh7wym204wlcgplmx0mna2fd97v398rvhu829a7xc757kqfwngcy8kv5vdj5chm26msfz64c4mn8nnta36ua8r7a9ql7lxps60v65mf7hl44t2dx3wp3sxkm8k0eaxfwaqvgg78f55rvra4u4wx0xmpt7h8rj8c287lnjk7xmudflnvnt70pvxq3wn5vfhk8jw86vvyl8nhhewcefljwueym7eyuaaud77uc9c6g6xtqjzzr0v348g0rzwsl7pl8gwrxpdxgvskj76ql5428c0awchrlwrhnwfkm55ayhmac37wyl6ydxx93dddcnmlkzjx0lllq3vqh2ks8w33ehcyfu0tjw07jtl38le0az2aaam57s9jxx6n7eh3g4j778l592vjvequ9qd4dmu5v6c09kht8v324uaaf0t0e8zx2lj2ec0m2hggk59t3ugcnkz6qnqrrzwcgxd7jgcwzp9lvxqwal83xtleqfrkpur0klh6xuc7td9jf2h949nvk0hc0qrl9ne7gs4303gl4ljqv4r5jj2pkz2tuljjvddxg5n2v7dcs5tnt95ks5twvx99sknrjdcy276pt9g5gct7244ctzdewpy4uczjd70msjdjwpr47sdp0p5hhzrg2d32ghmxg9dtqhjltdyhqjt72p3842j7fen9adlllupyzvdjspfhhk29j5zjt7den9u2j77gr8avscy7dae9z6m3fzc8uknxte3gl03jt8xpstg5a609h9ymnxtfj80wnwvqg99f3smrt5pte99qd7e3vtq4x6y49lajmu4cja7snu740z3m4mwaz4wewpx4sc047m6hf443p0swajmnfedr0yktk2f4xtp2fff996mnp29r8jaqj2ynn4vxgh6k2kveg5zan3de98rzvfd998ntnfde24uc2e0x4x5cje09nx6stxyuk6nqc4aj6d44y5cjfvfyjxcwavut7tegrhntetqw9a89vn3g942rx2fweqhynn3w9c6nvvff9n9zlnzffyhzk2jfeltu7t7tff8v422v4j4zc2xv4fyvktw2f89j23w5ur7xa46xuezlhk095jpa6x7cjfvevj5ul7deh8uhn3833ujj23vefxjjtx0e0rcnlxwf49uuf2tmq55xjgthzlns3qkgztguq2psqgep0lvewt4stk4kj960xn7fhmzjeu5z22han9v44prc50xuklwzrkdglsyuntccp2wka8ly9l6pv7a2r9w0xj0fq90dpza3u765dwfkmyjpnkf323kdzhcff0f0awaulh23v0vmu448alxumjs6hk4xemkd4dmk7yze4u7h9wtxvh4mm7x22qccnj9522p8g6njx348ygymneh7ap2jtv83gk02sj2fmpmhta9te0625xdyg027utecw80ws4dlcnt3d6vtn7ds7pg4mfkm4f40qe230xl3wm7sermj6uv4rft06xd0lzdgy6tmkkac4su4nnv3vls2alvfq993qwfmusmnhepkzjn0ml7nhq3tkcdf0m6wt2gzfwn2ar3etyktynpxaju00dvlms4jm0egxe7md8h57pjp232eztprly8juq85fj66cdmpyrkeuyx6cva0emjx7wvkw4vwwl44el0h2urxzhha3ux5he88sa887t863ls0ctcdknj75g88ahvjuwk8fvt2era8jkdgmzq5hl07hlsun88xt70p8yh6z60lnkf4tet9ruwgm0j3h5r6dmhxfl4seh7wx07m7llpdffl2lw8372hzjmc0up8h75yv9qc862kc2fh8hs2g7pulvua4jl74z0kr95pgmsvqrs8xm0yqrxclrnqxs3zejg2cq0vecf4gzpjn5vw8l7mle06rsrc7dalj6uxnrx650jhm7e020ekl88u87g7g287746hdtw8lu4u5chje3m0enanj6w9tphm0e8y0vk9kd6y0nafju95kr3ezvwjl84almpk25t5uz9dfnlnfn33lk6cfdhpe7jh46l73y0chlh7ua2ja0mufvru03c4nu7m34fxr4wh6hdd4z7zqd63nyeuke7d95yanndczv24h8lutdu63ljgycqdnr4hgcc6c2gl";
            bool dropOnly = false;

            // Act
            PostOffer_Response result = Offers_Client.PostOffer_Sync(offer, dropOnly);

            // Assert
            Assert.True(result.success);
            Assert.NotNull(result.id);
            //Assert.True(result.known);
            //Assert.NotNull(result.offer);
            //Assert.Equal(4, result.offer.status);
            //Assert.NotNull(result.offer.date_found);
            //Assert.NotNull(result.offer.date_completed);
            //Assert.NotNull(result.offer.date_pending);
            //Assert.NotEqual(0, result.offer.spent_block_index);
            //Assert.NotEqual(0, result.offer.price);
            //Assert.NotNull(result.offer.offered);
            //Assert.NotNull(result.offer.requested);
            //Assert.Equal(0, result.offer.fees);
        }
        [Fact]
        public void  TestGetOffer()
        {
            // own offer
            string[] offerIDs = new[] 
            { 
                "HBfDkanVUwyiJBwx2jsrFmWKxm7CKjMvhYfqPMoNQQWz",
                "BE2uoNNidyqJBX3gqcfPm3caYi8HMdvtuEMLBqTLVK7G",
                "9sYEERW6LwCAMoVmfRCyxbBkSMGRMrfbzSPmrWCRFHWo",
            };

            // sample offes
            //string offerID = "HR7aHbCXsJto7iS9uBkiiGJx6iGySxoNqUGQvrZfnj6B";
            foreach (string id in offerIDs)
            {
                GetOffer_Response? offer = Offers_Client.GetOffer_Sync(id);
            }
            
            { }
        }
    }
}
