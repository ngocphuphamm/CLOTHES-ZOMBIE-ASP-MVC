(function ($) {
  'use strict';

  let data = [
    {
      nameProduct: '#1 BLUE STRIPES SWEATER - WHITE',
      price: 350,
      size: [
        { sizeName: 'XL', qty: 10 },
        { sizeName: 'L', qty: 5 },
        { sizeName: 'M', qty: 5 },
      ],
      description: {
        imageList: [
          '//product.hstatic.net/200000321771/product/upload_108ae7b404744e37990c60736bbc0f33_grande.jpg',
          '//product.hstatic.net/200000321771/product/upload_2e9fd2109fcf464e87fafe9e32cf07a1_grande.jpg',
        ],
        productDes:
          'Vải cotton hút ẩm tốt ,mịn mát,co giãn, dày vừa ko bí, mang đến cảm giác dễ chịu cho người sử dụng.',
        price: 350,
        type: '621df18f81c5aa40061ef709',
        collection: '621c50a7bae8653bcb4564b1',
      },
      discount: 'ObjectId',
    },
    {
      nameProduct: '#1 EXTENDED TEE LONG TEE - BLACK',
      price: 200,
      size: [
        { sizeName: 'XL', qty: 10 },
        { sizeName: 'L', qty: 5 },
        { sizeName: 'M', qty: 5 },
      ],
      description: {
        imageList: [
          '//product.hstatic.net/200000321771/product/1_1_ba315937a5984881ac4ad8b509ea44de_grande.jpg',
          '//product.hstatic.net/200000321771/product/1_2_29d878275a9d44c0a9356f55475aaa50_grande.jpg',
        ],
        productDes:
          'Vải cotton hút ẩm tốt ,mịn mát,co giãn, dày vừa ko bí, mang đến cảm giác dễ chịu cho người sử dụng.',
        price: 200,
        type: '621df18f81c5aa40061ef709',
        collection: '621c50a7bae8653bcb4564b1',
      },
      discount: 'ObjectId',
    },
    {
      nameProduct: '#1 EXTENDED TEE LONG TEE - WHITE',
      price: 200,
      size: [
        { sizeName: 'XL', qty: 10 },
        { sizeName: 'L', qty: 5 },
        { sizeName: 'M', qty: 5 },
      ],
      description: {
        imageList: [
          '//product.hstatic.net/200000321771/product/7_1_9c9748d992f644bd9b8bdfb1f3e4d632_grande.jpg',
          '//product.hstatic.net/200000321771/product/7_2_d3b5c8fae72f4d0d9d7bdaffbbbc5150_grande.jpg',
        ],
        productDes:
          'Vải cotton hút ẩm tốt ,mịn mát,co giãn, dày vừa ko bí, mang đến cảm giác dễ chịu cho người sử dụng.',
        price: 200,
        type: '621df18f81c5aa40061ef709',
        collection: '621c50a7bae8653bcb4564b1',
      },
      discount: 'ObjectId',
    },
    {
      nameProduct: '#1 Hoodie Basic In White',
      price: 240,
      size: [
        { sizeName: 'XL', qty: 10 },
        { sizeName: 'L', qty: 5 },
        { sizeName: 'M', qty: 5 },
      ],
      description: {
        imageList: [
          '//product.hstatic.net/200000321771/product/ash_0102-edit_a81950f62e6e40e58bf675ace6207698_grande.jpg',
          '//product.hstatic.net/200000321771/product/ash_0104-edit_583379c17384465f9ea4596a8f151a6b_grande.jpg',
        ],
        productDes:
          'Vải cotton hút ẩm tốt ,mịn mát,co giãn, dày vừa ko bí, mang đến cảm giác dễ chịu cho người sử dụng.',
        price: 240,
        type: '621df18f81c5aa40061ef709',
        collection: '621c50a7bae8653bcb4564b1',
      },
      discount: 'ObjectId',
    },
    {
      nameProduct: '#1 Jacket In Black',
      price: 320,
      size: [
        { sizeName: 'XL', qty: 10 },
        { sizeName: 'L', qty: 5 },
        { sizeName: 'M', qty: 5 },
      ],
      description: {
        imageList: [
          '//product.hstatic.net/200000321771/product/9_1_0aeeafe595834f919b6abe5a2aefb7fa_grande.jpg',
          '//product.hstatic.net/200000321771/product/9_2_592cfb205c6d49a09e928e3974d622a5_grande.jpg',
        ],
        productDes:
          'Vải cotton hút ẩm tốt ,mịn mát,co giãn, dày vừa ko bí, mang đến cảm giác dễ chịu cho người sử dụng.',
        price: 320,
        type: '621df18f81c5aa40061ef709',
        collection: '621c50a7bae8653bcb4564b1',
      },
      discount: 'ObjectId',
    },
    {
      nameProduct: '#1 JACKET IN CAMO',
      price: 350,
      size: [
        { sizeName: 'XL', qty: 10 },
        { sizeName: 'L', qty: 5 },
        { sizeName: 'M', qty: 5 },
      ],
      description: {
        imageList: [
          '//product.hstatic.net/200000321771/product/upload_bcc1e13b1cde408ab98c2a535c7fcdc8_grande.jpg',
          '//product.hstatic.net/200000321771/product/upload_aab67cd7844d41428f4b4e1a8b07c7ff_grande.jpg',
        ],
        productDes:
          'Vải cotton hút ẩm tốt ,mịn mát,co giãn, dày vừa ko bí, mang đến cảm giác dễ chịu cho người sử dụng.',
        price: 350,
        type: '621df18f81c5aa40061ef709',
        collection: '621c50a7bae8653bcb4564b1',
      },
      discount: 'ObjectId',
    },
    {
      nameProduct: '#1 Long Sleeve Long Tee - Black',
      price: 250,
      size: [
        { sizeName: 'XL', qty: 10 },
        { sizeName: 'L', qty: 5 },
        { sizeName: 'M', qty: 5 },
      ],
      description: {
        imageList: [
          '//product.hstatic.net/200000321771/product/upload_d362c6d27a2a4a8da7960636bb7ced08_grande.jpg',
          '//product.hstatic.net/200000321771/product/2p6a9552-edit__1__aac5c5d4fafe4ed898e00c5b6c1ff405_grande.jpg',
        ],
        productDes:
          'Vải cotton hút ẩm tốt ,mịn mát,co giãn, dày vừa ko bí, mang đến cảm giác dễ chịu cho người sử dụng.',
        price: 250,
        type: '621df18f81c5aa40061ef709',
        collection: '621c50a7bae8653bcb4564b1',
      },
      discount: 'ObjectId',
    },
    {
      nameProduct: '#1 Long Sleeve Long Tee - White',
      price: 250,
      size: [
        { sizeName: 'XL', qty: 10 },
        { sizeName: 'L', qty: 5 },
        { sizeName: 'M', qty: 5 },
      ],
      description: {
        imageList: [
          '//product.hstatic.net/200000321771/product/upload_d4199468e2d242f1860acf24e34ed082_grande.jpg',
          '//product.hstatic.net/200000321771/product/upload_1ec538fd8deb42efa300cab029d42e10_grande.jpg',
        ],
        productDes:
          'Vải cotton hút ẩm tốt ,mịn mát,co giãn, dày vừa ko bí, mang đến cảm giác dễ chịu cho người sử dụng.',
        price: 250,
        type: '621df18f81c5aa40061ef709',
        collection: '621c50a7bae8653bcb4564b1',
      },
      discount: 'ObjectId',
    },
    {
      nameProduct: '#1 Sweater In Red',
      price: 300,
      size: [
        { sizeName: 'XL', qty: 10 },
        { sizeName: 'L', qty: 5 },
        { sizeName: 'M', qty: 5 },
      ],
      description: {
        imageList: [
          '//product.hstatic.net/200000321771/product/upload_1a68c3a0869948f8818daa27c57fb5ba_grande.jpg',
          '//product.hstatic.net/200000321771/product/ash_0100-edit_0542d24b6d474f70bec681865511aa13_grande.jpg',
        ],
        productDes:
          'Vải cotton hút ẩm tốt ,mịn mát,co giãn, dày vừa ko bí, mang đến cảm giác dễ chịu cho người sử dụng.',
        price: 300,
        type: '621df18f81c5aa40061ef709',
        collection: '621c50a7bae8653bcb4564b1',
      },
      discount: 'ObjectId',
    },
    {
      nameProduct: '#2 Sweater In Black',
      price: 280,
      size: [
        { sizeName: 'XL', qty: 10 },
        { sizeName: 'L', qty: 5 },
        { sizeName: 'M', qty: 5 },
      ],
      description: {
        imageList: [
          '//product.hstatic.net/200000321771/product/4_1_05ac4a56e9ec43e1a6f1f4127a127d33_grande.jpg',
          '//product.hstatic.net/200000321771/product/4_2_2a882c5cd80a4b458e9fee39ec642d51_grande.jpg',
        ],
        productDes:
          'Vải cotton hút ẩm tốt ,mịn mát,co giãn, dày vừa ko bí, mang đến cảm giác dễ chịu cho người sử dụng.',
        price: 280,
        type: '621df18f81c5aa40061ef709',
        collection: '621c50a7bae8653bcb4564b1',
      },
      discount: 'ObjectId',
    },
    {
      nameProduct: '#3 EXTENDED TEE - BLACK',
      price: 200,
      size: [
        { sizeName: 'XL', qty: 10 },
        { sizeName: 'L', qty: 5 },
        { sizeName: 'M', qty: 5 },
      ],
      description: {
        imageList: [
          '//product.hstatic.net/200000321771/product/upload_9514df9adfd243a892c7feb339d7d409_master_1b89a33a767744e09577c2ccd7a48381_grande.jpg',
          '//product.hstatic.net/200000321771/product/upload_3febcde5bc0a4430a5433bdccba2faab_master_470a61d074f3492faf352ed8192153ee_grande.jpg',
        ],
        productDes:
          'Vải cotton hút ẩm tốt ,mịn mát,co giãn, dày vừa ko bí, mang đến cảm giác dễ chịu cho người sử dụng.',
        price: 200,
        type: '621df18f81c5aa40061ef709',
        collection: '621c50a7bae8653bcb4564b1',
      },
      discount: 'ObjectId',
    },
    {
      nameProduct: '#3 EXTENDED TEE - WHITE',
      price: 200,
      size: [
        { sizeName: 'XL', qty: 10 },
        { sizeName: 'L', qty: 5 },
        { sizeName: 'M', qty: 5 },
      ],
      description: {
        imageList: [
          '//product.hstatic.net/200000321771/product/upload_9bea0d7b60d44bbcb84315d0059a6202_grande.jpg',
          '//product.hstatic.net/200000321771/product/upload_3aa29c8163ca4118a85949b632fd8f51_grande.jpg',
        ],
        productDes:
          'Vải cotton hút ẩm tốt ,mịn mát,co giãn, dày vừa ko bí, mang đến cảm giác dễ chịu cho người sử dụng.',
        price: 200,
        type: '621df18f81c5aa40061ef709',
        collection: '621c50a7bae8653bcb4564b1',
      },
      discount: 'ObjectId',
    },
    {
      nameProduct: '000388 OXFORD SHIRT IN BLACK',
      price: 250,
      size: [
        { sizeName: 'XL', qty: 10 },
        { sizeName: 'L', qty: 5 },
        { sizeName: 'M', qty: 5 },
      ],
      description: {
        imageList: [
          '//product.hstatic.net/200000321771/product/upload_fb3677d1176f4955ac9b30102ae5049e_grande.jpg',
          '//product.hstatic.net/200000321771/product/upload_ee5ab3b9e48746538db1a97413bdd8a8_grande.jpg',
        ],
        productDes:
          'Vải cotton hút ẩm tốt ,mịn mát,co giãn, dày vừa ko bí, mang đến cảm giác dễ chịu cho người sử dụng.',
        price: 250,
        type: '621df18f81c5aa40061ef709',
        collection: '621c50a7bae8653bcb4564b1',
      },
      discount: 'ObjectId',
    },
    {
      nameProduct: '3576 DENIM TRUCKER JACKET',
      price: 350,
      size: [
        { sizeName: 'XL', qty: 10 },
        { sizeName: 'L', qty: 5 },
        { sizeName: 'M', qty: 5 },
      ],
      description: {
        imageList: [
          '//product.hstatic.net/200000321771/product/upload_11885c305f4d42f594f242c37dcc52c1_grande.jpg',
          '//product.hstatic.net/200000321771/product/upload_97a6c1958d7543bbad26093e2bd718cc_grande.jpg',
        ],
        productDes:
          'Vải cotton hút ẩm tốt ,mịn mát,co giãn, dày vừa ko bí, mang đến cảm giác dễ chịu cho người sử dụng.',
        price: 350,
        type: '621df18f81c5aa40061ef709',
        collection: '621c50a7bae8653bcb4564b1',
      },
      discount: 'ObjectId',
    },
    {
      nameProduct: '5477 OXFORD SHIRT IN WHITE',
      price: 250,
      size: [
        { sizeName: 'XL', qty: 10 },
        { sizeName: 'L', qty: 5 },
        { sizeName: 'M', qty: 5 },
      ],
      description: {
        imageList: [
          '//product.hstatic.net/200000321771/product/ash_0001-edit__1__6455e56d0c674da18013847e9e062c73_grande.jpg',
          '//product.hstatic.net/200000321771/product/ash_0002-edit__1__144217f9c0a14758b59aac8d6a1752e6_grande.jpg',
        ],
        productDes:
          'Vải cotton hút ẩm tốt ,mịn mát,co giãn, dày vừa ko bí, mang đến cảm giác dễ chịu cho người sử dụng.',
        price: 250,
        type: '621df18f81c5aa40061ef709',
        collection: '621c50a7bae8653bcb4564b1',
      },
      discount: 'ObjectId',
    },
    {
      nameProduct: '6305 TRUCKER DENIM BLACK',
      price: 350,
      size: [
        { sizeName: 'XL', qty: 10 },
        { sizeName: 'L', qty: 5 },
        { sizeName: 'M', qty: 5 },
      ],
      description: {
        imageList: [
          '//product.hstatic.net/200000321771/product/upload_610e5fed39404f79b632809521436a15_grande.jpg',
          '//product.hstatic.net/200000321771/product/upload_01bd0ecce1534117bffdd68e0ca1f16a_grande.jpg',
        ],
        productDes:
          'Vải cotton hút ẩm tốt ,mịn mát,co giãn, dày vừa ko bí, mang đến cảm giác dễ chịu cho người sử dụng.',
        price: 350,
        type: '621df18f81c5aa40061ef709',
        collection: '621c50a7bae8653bcb4564b1',
      },
      discount: 'ObjectId',
    },
    {
      nameProduct: '6386 Hoodie Jacket Jeans In Black',
      price: 420,
      size: [
        { sizeName: 'XL', qty: 10 },
        { sizeName: 'L', qty: 5 },
        { sizeName: 'M', qty: 5 },
      ],
      description: {
        imageList: [
          '//product.hstatic.net/200000321771/product/upload_a53038a4cb704e1fa528c5a9a33d3e86_grande.jpg',
          '//product.hstatic.net/200000321771/product/upload_0e7f07a7f1d843ac85286457a56d1be8_grande.jpg',
        ],
        productDes:
          'Vải cotton hút ẩm tốt ,mịn mát,co giãn, dày vừa ko bí, mang đến cảm giác dễ chịu cho người sử dụng.',
        price: 420,
        type: '621df18f81c5aa40061ef709',
        collection: '621c50a7bae8653bcb4564b1',
      },
      discount: 'ObjectId',
    },
    {
      nameProduct: '6774 JACKET CAMO',
      price: 280,
      size: [
        { sizeName: 'XL', qty: 10 },
        { sizeName: 'L', qty: 5 },
        { sizeName: 'M', qty: 5 },
      ],
      description: {
        imageList: [
          '//product.hstatic.net/200000321771/product/upload_07ea8fef064b4c1fae275759ceea46b7_grande.jpg',
          '//product.hstatic.net/200000321771/product/upload_f124d1da35cd49f4859cad2491c06eaf_grande.jpg',
        ],
        productDes:
          'Vải cotton hút ẩm tốt ,mịn mát,co giãn, dày vừa ko bí, mang đến cảm giác dễ chịu cho người sử dụng.',
        price: 280,
        type: '621df18f81c5aa40061ef709',
        collection: '621c50a7bae8653bcb4564b1',
      },
      discount: 'ObjectId',
    },
    {
      nameProduct: '7064 PLAID HOODIE IN W.GREY',
      price: 300,
      size: [
        { sizeName: 'XL', qty: 10 },
        { sizeName: 'L', qty: 5 },
        { sizeName: 'M', qty: 5 },
      ],
      description: {
        imageList: [
          '//product.hstatic.net/200000321771/product/upload_6c6bd4f755b1473fb7bd621749f337f6_grande.jpg',
          '//product.hstatic.net/200000321771/product/upload_85c05eeff6fd4690978b422624c0951f_grande.jpg',
        ],
        productDes:
          'Vải cotton hút ẩm tốt ,mịn mát,co giãn, dày vừa ko bí, mang đến cảm giác dễ chịu cho người sử dụng.',
        price: 300,
        type: '621df18f81c5aa40061ef709',
        collection: '621c50a7bae8653bcb4564b1',
      },
      discount: 'ObjectId',
    },
    {
      nameProduct: '7357 LEOPARD BOMBER JACKET',
      price: 380,
      size: [
        { sizeName: 'XL', qty: 10 },
        { sizeName: 'L', qty: 5 },
        { sizeName: 'M', qty: 5 },
      ],
      description: {
        imageList: [
          '//product.hstatic.net/200000321771/product/upload_d7039c2e19d74cc78b2a1909a532065f_grande.jpg',
          '//product.hstatic.net/200000321771/product/upload_5b5d582d9b264897b16e3e59dddf4b69_grande.jpg',
        ],
        productDes:
          'Vải cotton hút ẩm tốt ,mịn mát,co giãn, dày vừa ko bí, mang đến cảm giác dễ chịu cho người sử dụng.',
        price: 380,
        type: '621df18f81c5aa40061ef709',
        collection: '621c50a7bae8653bcb4564b1',
      },
      discount: 'ObjectId',
    },
  ];

  function TaoSoNgauNhien(min, max) {
    return Math.floor(Math.random() * (max - min)) + min;
  }

  let html = '';

  let modal = `
  <div class="modal fade" id="staticBackdrop" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="staticBackdropLabel" aria-hidden="true">
  <div class="modal-dialog">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title" id="staticBackdropLabel">Xóa sản phẩm</h5>
        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
      </div>
      <div class="modal-body">
        Bạn có chắc muốn xóa sản phẩm này
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-primary" data-bs-dismiss="modal">Hủy</button>
        <button type="button" class="btn btn-danger">Xóa</button>
      </div>
    </div>
  </div>
</div>`;
  data.forEach((item) => {
    html += `
            <tr>
                <td>${TaoSoNgauNhien(10, 2000)}</td>
                <td class="text-left">${item.nameProduct}</td>
                <td>Áo thun</td>
                <td>
                <img
                  src="${item.description.imageList[0]}"
                  width="70px"
                  height="70px"
                  alt=""
                />
              </td>
               
                <td>${item.price},000đ</td>
            
                <td>${TaoSoNgauNhien(10, 300)}</td>
                <td>
                <button  type="button" class="btn btn-update btn-w-100 btn-outline-primary">
                 Cập nhật
                </button>
                <!-- Modal -->
            

              </td>
              <td>
              <button type="button" data-bs-toggle="modal" data-bs-target="#staticBackdrop" class=" btn btn-delete btn-w-80 btn-outline-danger">
                Xóa
              </button>
              ${modal}
            </td>
            
            </tr>
        
        `;
  });

  $('#renderData').html(html);

  //   jquey database

  var table = $('#table-product').DataTable();
  // get data từng dòng

  $('#table-product tbody').on('click', 'tr .btn-update', function () {
    let td = $(this).parent();
    let tr = td.parent();
    var data = table.row(tr).data();
    //set data cho modal
    //data[1],2,3
    $('.update-nameProduct').val(data[1]);
    $('.update-category').val(data[2]);
    let price = data[4].slice(0, 3);

    $('.update-price').val(price);

    $('.modal-update').css('display', 'flex');
  });

  $('.modal__overplay').click(function () {
    $('.modal-cus').toggle();
  });
})(jQuery);
