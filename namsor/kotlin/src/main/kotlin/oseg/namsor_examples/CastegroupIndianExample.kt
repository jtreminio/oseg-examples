package oseg.namsor_examples

import app.namsor.client.infrastructure.*
import app.namsor.client.apis.*
import app.namsor.client.models.*

import java.io.File
import java.time.LocalDate
import java.time.OffsetDateTime
import kotlin.collections.ArrayList
import kotlin.collections.List
import kotlin.collections.Map
import com.squareup.moshi.adapter

@ExperimentalStdlibApi
class CastegroupIndianExample
{
    fun castegroupIndian()
    {
        ApiClient.apiKey["X-API-KEY"] = "YOUR_API_KEY"

        try
        {
            val response = IndianApi().castegroupIndian(
                subDivisionIso31662 = "IN-UP",
                firstName = "Akash",
                lastName = "Sharma",
            )

            println(response)
        } catch (e: ClientException) {
            println("4xx response calling IndianApi#castegroupIndian")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling IndianApi#castegroupIndian")
            e.printStackTrace()
        }
    }
}
