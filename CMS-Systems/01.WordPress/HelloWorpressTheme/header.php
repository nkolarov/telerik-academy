<!DOCTYPE HTML>
<html>

<head>
  <title>CSS3_colour3</title>
  <meta name="description" content="website description" />
  <meta name="keywords" content="website keywords, website keywords" />
  <meta http-equiv="content-type" content="text/html; charset=UTF-8" />
  <link rel="stylesheet" type="text/css" href="<?php bloginfo('stylesheet_url');?>" />
  <!-- modernizr enables HTML5 elements and feature detects -->
  <script type="text/javascript" src="<?php echo get_template_directory_uri();?>/js/modernizr-1.5.min.js"></script>
</head>

<body>
  <div id="main">
    <header>
      <div id="logo">
        <div id="logo_text">
          <!-- class="logo_colour", allows you to change the colour of the text -->
          <h1><a href="<?php echo home_url();?>">CSS3<span class="logo_colour">_colour3</span></a></h1>
          <h2>Simple. Contemporary. Website Template.</h2>
        </div>
      </div>
      <nav>
        <div id="menu_container">
			<?php 
				$menu_data = array(  
					'theme_location'  => 'top-site-menu',  
					'container'       => 'ul',  
					'container_class' => 'menu-{menu slug}-container',  
					'menu_class'      => 'menu',  
					'echo'            => true,  
					'fallback_cb'     => 'wp_page_menu',  
					'items_wrap'      => '<ul id="nav" class="sf-menu">%3$s</ul>',  
					'depth'           => 0
				); 
				wp_nav_menu( $menu_data );
			  ?>
        </div>
      </nav>
    </header>
    <div id="site_content">
		
      <div id="sidebar_container">
	  <?php get_sidebar('left-sidebar');?>

      </div>
      <div class="content">