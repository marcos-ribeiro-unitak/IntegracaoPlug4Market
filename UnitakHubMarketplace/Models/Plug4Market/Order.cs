using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitakHubMarketplace.Models.Plug4Market
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Billing
    {
        public string name { get; set; }
        public string email { get; set; }
        public string documentId { get; set; }
        public string street { get; set; }
        public string streetNumber { get; set; }
        public string streetComplement { get; set; }
        public string district { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string country { get; set; }
        public string zipCode { get; set; }
        public string phone { get; set; }
        public string gender { get; set; }
        public DateTime? dateOfBirth { get; set; }
        public bool taxPayer { get; set; }
    }

    public class Invoice
    {
        public DateTime nfeDate { get; set; }
        public string nfeNumber { get; set; }
        public string nfeSerialNumber { get; set; }
        public string nfeAccessKey { get; set; }
        public string xml { get; set; }
        public void Fill(Order order, DataTable dt) {
            order.invoice = new Invoice();
            order.invoice.nfeDate = DateTime.Parse(dt.Rows[0]["Data_Emissao"].ToString());
            order.invoice.nfeNumber = dt.Rows[0]["ID_Nfe"].ToString();
            order.invoice.nfeSerialNumber = dt.Rows[0]["ID_Serie"].ToString();
            order.invoice.nfeAccessKey = dt.Rows[0]["NFE"].ToString();// "23220842378107000118550010000001481546807543";
            order.invoice.xml = dt.Rows[0]["XML"].ToString();// "<?xml version=\"1.0\" encoding=\"UTF-8\"?><nfeProc versao=\"4.00\" xmlns=\"http://www.portalfiscal.inf.br/nfe\"><NFe xmlns=\"http://www.portalfiscal.inf.br/nfe\"><infNFe Id=\"NFe33220136577542000179550010000052741126595448\" versao=\"4.00\"><ide><cUF>33</cUF><cNF>12659544</cNF><natOp>DEVOLUCAO DE VENDA DE MERCADORIA ADQUIRIDA OU RECEBIDA DE TE</natOp><mod>55</mod><serie>1</serie><nNF>5274</nNF><dhEmi>2022-01-21T10:33:08-03:00</dhEmi><tpNF>0</tpNF><idDest>1</idDest><cMunFG>3302403</cMunFG><tpImp>1</tpImp><tpEmis>1</tpEmis><cDV>8</cDV><tpAmb>2</tpAmb><finNFe>4</finNFe><indFinal>1</indFinal><indPres>1</indPres><procEmi>0</procEmi><verProc>7.15</verProc><NFref><refNFe>33220101183645000412650010002305991210718299</refNFe></NFref></ide><emit><CNPJ>36577542000179</CNPJ><xNome>EXATA Macae Tecnologia Ltda</xNome><xFant>EXATA Sistemas</xFant><enderEmit><xLgr>Rua Euzebio de Queiroz</xLgr><nro>600</nro><xBairro>Centro</xBairro><cMun>3302403</cMun><xMun>Macae</xMun><UF>RJ</UF><CEP>27910230</CEP><cPais>1058</cPais><xPais>Brasil</xPais><fone>2227628679</fone></enderEmit><IE>84663018</IE><CRT>3</CRT></emit><dest><CPF>52495345700</CPF><xNome>NF-E EMITIDA EM AMBIENTE DE HOMOLOGACAO - SEM VALOR FISCAL</xNome><enderDest><xLgr>RUA RUY FIGUEIREDO BORGES</xLgr><nro>79</nro><xBairro>PRAIA DO PECADO</xBairro><cMun>3302403</cMun><xMun>Macae</xMun><UF>RJ</UF><CEP>27920470</CEP><cPais>1058</cPais><xPais>BRASIL</xPais><fone>2227628679</fone></enderDest><indIEDest>9</indIEDest></dest><det nItem=\"1\"><prod><cProd>72724</cProd><cEAN>7898449142251</cEAN><xProd>1 - REJUNTE ACRI.BICOMPONENTE PLATINA 1KG  CERAMFIX - 603889</xProd><NCM>38245000</NCM><CEST>1000200</CEST><CFOP>1411</CFOP><uCom>UN</uCom><qCom>1.000</qCom><vUnCom>51.6500</vUnCom><vProd>51.65</vProd><cEANTrib>7898449142251</cEANTrib><uTrib>UN</uTrib><qTrib>1.000</qTrib><vUnTrib>51.6500</vUnTrib><vDesc>15.50</vDesc><indTot>1</indTot><nItemPed>0</nItemPed></prod><imposto><vTotTrib>4.86</vTotTrib><ICMS><ICMS60><orig>0</orig><CST>60</CST></ICMS60></ICMS><IPI><cEnq>999</cEnq><IPINT><CST>01</CST></IPINT></IPI><PIS><PISOutr><CST>50</CST><vBC>36.15</vBC><pPIS>1.65</pPIS><vPIS>0.60</vPIS></PISOutr></PIS><COFINS><COFINSOutr><CST>50</CST><vBC>36.15</vBC><pCOFINS>7.60</pCOFINS><vCOFINS>2.75</vCOFINS></COFINSOutr></COFINS></imposto></det><total><ICMSTot><vBC>0.00</vBC><vICMS>0.00</vICMS><vICMSDeson>0.00</vICMSDeson><vFCPUFDest>0.00</vFCPUFDest><vICMSUFDest>0.00</vICMSUFDest><vICMSUFRemet>0.00</vICMSUFRemet><vFCP>0.00</vFCP><vBCST>0</vBCST><vST>0.00</vST><vFCPST>0.00</vFCPST><vFCPSTRet>0.00</vFCPSTRet><vProd>51.65</vProd><vFrete>0.00</vFrete><vSeg>0.00</vSeg><vDesc>15.50</vDesc><vII>0.00</vII><vIPI>0.00</vIPI><vIPIDevol>0.00</vIPIDevol><vPIS>0.60</vPIS><vCOFINS>2.75</vCOFINS><vOutro>0.00</vOutro><vNF>36.15</vNF><vTotTrib>4.86</vTotTrib></ICMSTot></total><transp><modFrete>0</modFrete><vol><qVol>1</qVol><esp>Volume(s)</esp><nVol>0</nVol><pesoL>1.000</pesoL><pesoB>1.000</pesoB></vol></transp><pag><detPag><tPag>90</tPag><vPag>0</vPag></detPag></pag><infAdic><infCpl>Vendedor: MATHEUS GOMES DA SILVA]Procon Rua da Ajuda, 05 - RJ DisqueProcon 151]ALERJ  Rua da Alfandega, 08 - RJ  08002827060] ] TRIB. APROX. Fed: R$4,86 Est: R$0,00 Mun: R$0,00 Fonte: IBPT ] NF-e referenciada - 33220101183645000412650010002305991210718299</infCpl></infAdic></infNFe><Signature xmlns=\"http://www.w3.org/2000/09/xmldsig#\"><SignedInfo><CanonicalizationMethod Algorithm=\"http://www.w3.org/TR/2001/REC-xml-c14n-20010315\"/><SignatureMethod Algorithm=\"http://www.w3.org/2000/09/xmldsig#rsa-sha1\"/><Reference URI=\"#NFe33220136577542000179550010000052741126595448\"><Transforms><Transform Algorithm=\"http://www.w3.org/2000/09/xmldsig#enveloped-signature\"/><Transform Algorithm=\"http://www.w3.org/TR/2001/REC-xml-c14n-20010315\"/></Transforms><DigestMethod Algorithm=\"http://www.w3.org/2000/09/xmldsig#sha1\"/><DigestValue>87hOb1wCNH5GTH+MbXkdM6AAAc8=</DigestValue></Reference></SignedInfo><SignatureValue>MjBeKDGrbfvmdcdOKt/HrtUWAcrzREh1RtIWZHKp0gVtWk75GgBz37H6Aab8rtO9ZNTBVqG6QEQM7lfUsQ3rt78kvaT0MAMm3ChoNJtjJKA9t4x5c3FKl+V78Td0X21+6aZmipmVTD44mynJgJMdL6/var3pZdzFE4o1aJMWrkPs3aNxm9sHwlwEZfSK9WHFFglTyrX5xqSFaYnc2lfxySBdBbB4rTZ7gmfYwxn4Y/ByiE2T2X8xF6TLF/ru9reNOPpwE1q81gLYeA8h+FJxXKZmqsiAv+9R8Bk4dgpZv2oEUbK8D+Z77n86RfAeMnRUks9IhkbyJApuqJym9mQ6qA==</SignatureValue><KeyInfo><X509Data><X509Certificate>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</X509Certificate></X509Data></KeyInfo></Signature></NFe><protNFe versao=\"4.00\"><infProt><tpAmb>2</tpAmb><verAplic>SVRS202201190856</verAplic><chNFe>33220136577542000179550010000052741126595448</chNFe><dhRecbto>2022-01-21T10:39:02-03:00</dhRecbto><nProt>333220000025946</nProt><digVal>87hOb1wCNH5GTH+MbXkdM6AAAc8=</digVal><cStat>100</cStat><xMotivo>Autorizado o uso da NF-e</xMotivo></infProt></protNFe></nfeProc>";
        }
    }


    public class OrderItem
    {
        public string orderItemId { get; set; }
        public string name { get; set; }
        public string mainImage { get; set; }
        public int quantity { get; set; }
        public double total { get; set; }
        public double price { get; set; }
        public double discount { get; set; }
        public int freight { get; set; }
        public double salePrice { get; set; }
        public double unitDiscount { get; set; }
        public double originalPrice { get; set; }
        public double originalTotal { get; set; }
        public string productId { get; set; }
        public string sku { get; set; }
        public string customId { get; set; }
    }

    public class PaymentMethod
    {
        public string method { get; set; }
        public double value { get; set; }
        public int installments { get; set; }
        public int sequential { get; set; }
        public string cardBrand { get; set; }
        public string authorization { get; set; }
    }

    public class Order
    {
        public string id { get; set; }
        public string saleChannel { get; set; }
        public int orderType { get; set; }
        public bool integratedSaleChannelStatus { get; set; }
        public string saleChannelOrderId { get; set; }
        public string orderIdSeller { get; set; }
        public string orderIdStore { get; set; }
        public bool? orderIdCustom { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
        public DateTime saleChannelCreated { get; set; }
        public string status { get; set; }
        public List<StatusUpdateDate> statusUpdateDate { get; set; }
        public DateTime? deliveredAt { get; set; }
        public DateTime? estimatedDeliveredAt { get; set; }
        public double totalAmount { get; set; }
        public double totalCommission { get; set; }
        public int shippingCost { get; set; }
        public int interest { get; set; }
        public List<PaymentMethod> paymentMethods { get; set; }
        public List<OrderItem> orderItems { get; set; }
        public Shipping shipping { get; set; }
        public Billing billing { get; set; }
        public Invoice invoice { get; set; }
        public Shipment shipment { get; set; }
        public int orderId { get; set; }
        public string note { get; set; }
        public string originalObjectJson { get; set; }
    }

    public class Shipment
    {
        public string shipmentId { get; set; }
        public string shippingCarrier { get; set; }
        public string trackingNumber { get; set; }
        public string trackingUrl { get; set; }
        public string shippingName { get; set; }
        public int total { get; set; }
    }

    public class Shipping
    {
        public string recipientName { get; set; }
        public string phone { get; set; }
        public string street { get; set; }
        public string streetNumber { get; set; }
        public string city { get; set; }
        public string streetComplement { get; set; }
        public string country { get; set; }
        public string district { get; set; }
        public string state { get; set; }
        public string zipCode { get; set; }
    }

    public class StatusUpdateDate
    {
        public DateTime? updateDate { get; set; }
        public string status { get; set; }
    }

    public class Links
    {
        public string first { get; set; }
        public string previous { get; set; }
        public string next { get; set; }
        public string last { get; set; }
    }

    public class Meta
    {
        public int totalItems { get; set; }
        public int itemsPerPage { get; set; }
        public int itemCount { get; set; }
        public int totalPages { get; set; }
        public int currentPage { get; set; }
    }

    public class RetornoOrders
    {
        public List<DataOrder> data { get; set; }
        public Links links { get; set; }
        public Meta meta { get; set; }
    }

    public class DataOrder    {
        public string id { get; set; }
        public string saleChannelOrderId { get; set; }
        public string orderIdStore { get; set; }
        public string storeOrderId { get; set; }
        public string status { get; set; }
        public string saleChannelId { get; set; }
        public int orderType { get; set; }
        public double amount { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
        public string orderSaleChannelId { get; set; }
        public string note { get; set; }
    }

}
