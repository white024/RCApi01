using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace RCApi01.Models
{
    public partial class RCContext : DbContext
    {
        public RCContext()
        {
        }

        public RCContext(DbContextOptions<RCContext> options)
            : base(options)
        {
        }

        public virtual DbSet<GelenKutusu> GelenKutusus { get; set; } = null!;
        public virtual DbSet<KullaniciList> KullaniciLists { get; set; } = null!;
        public virtual DbSet<Mesajlar> Mesajlars { get; set; } = null!;
        public virtual DbSet<UnutulanSifre> UnutulanSifres { get; set; } = null!;
        public virtual DbSet<YoneticiGiris> YoneticiGirises { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("SERVER=MONSTER_ABRA_A5;Database=RC;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GelenKutusu>(entity =>
            {
                entity.HasKey(e => e.KullaniciAdi);

                entity.ToTable("gelen_kutusu");

                entity.Property(e => e.KullaniciAdi)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("kullanici_adi");

                entity.Property(e => e.Mesaj).HasColumnName("mesaj");
            });

            modelBuilder.Entity<KullaniciList>(entity =>
            {
                entity.HasKey(e => e.IdKullanici)
                    .HasName("PK_kullanici_list_1");

                entity.ToTable("kullanici_list");

                entity.Property(e => e.IdKullanici).HasColumnName("ID_kullanici");

                entity.Property(e => e.Durum).HasColumnName("durum");

                entity.Property(e => e.KullaniciAdiU)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("kullanici_adi_u");

                entity.Property(e => e.Sifre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("sifre");
            });

            modelBuilder.Entity<Mesajlar>(entity =>
            {
                entity.HasKey(e => e.MesajNo);

                entity.ToTable("mesajlar");

                entity.Property(e => e.MesajNo).HasColumnName("mesaj_no");

                entity.Property(e => e.IdAlici)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ID_alici");

                entity.Property(e => e.IdG).HasColumnName("ID_g");

                entity.Property(e => e.KullaniciAdiA)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("kullanici_adi_a");

                entity.Property(e => e.KullaniciAdiG)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("kullanici_adi_g");

                entity.Property(e => e.Mesaj)
                    .IsUnicode(false)
                    .HasColumnName("mesaj");

                entity.Property(e => e.MessageType)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("message_type");
            });

            modelBuilder.Entity<UnutulanSifre>(entity =>
            {
                entity.HasKey(e => e.UserSifre);

                entity.ToTable("unutulan_sifre");

                entity.Property(e => e.UserSifre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("user_sifre");

                entity.Property(e => e.UnutulanSifreA)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("unutulan_sifre_a");
            });

            modelBuilder.Entity<YoneticiGiris>(entity =>
            {
                entity.HasKey(e => e.IdYGiris);

                entity.ToTable("yonetici_giris");

                entity.Property(e => e.IdYGiris).HasColumnName("ID_y_giris");

                entity.Property(e => e.KullaniciAdiA)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("kullanici_adi_a");

                entity.Property(e => e.Sifre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("sifre");

                entity.Property(e => e.Tur)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("tur");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
